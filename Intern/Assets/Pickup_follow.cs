using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_follow : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Player;
    private float dis;
    private Vector3 posB;
    private Vector3 posP;
    private bool isHold = false;
    private float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rayDistance = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.forward;
        Vector3 rayPosition = transform.position + new Vector3(0.0f, -2.0f, 0.0f);
        Ray ray = new Ray(rayPosition, direction);
        Debug.DrawRay(rayPosition, direction * rayDistance, Color.red);

        posB = this.transform.position;
        posP = Player.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.name == "Ground")
            {
                Debug.Log("Hit");
            }
        }


        if (Dist(posB, posP))
        //if (Dist(posB, posP) && isHold)
        {
            if (Input.GetKeyUp("e"))
                isHold = true;
        }
        if (isHold)
        {

            this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.1f, Player.transform.position.z);

            if (Input.GetKeyDown("e"))
            {
                //ブロック設置処理


                isHold = false;

            }
        }
    }

    bool Dist(Vector3 pos1, Vector3 pos2)
    {
        dis = Vector3.Distance(pos1, pos2);
        if (dis < 1.2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
