using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_follow : MonoBehaviour
{
    Rigidbody rb;
    public GameObject PlayerPrefab;
    private float dis;
    private Vector3 posB;
    private Vector3 posP;
    private bool isHold = false;
    [SerializeField]
    private int pick_wait = 100;
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
        var direction = PlayerPrefab.transform.forward;
        Vector3 rayPosition = PlayerPrefab.transform.position + new Vector3(0.0f, -2.0f, 0.0f);
        Ray ray = new Ray(rayPosition, direction);
        Debug.DrawRay(rayPosition, direction * rayDistance, Color.red);
        pick_wait--;

        posB = this.transform.position;
        posP = PlayerPrefab.transform.position;

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
            if (Input.GetKeyUp("e") && pick_wait < 0)
            {
                isHold = true;
                rb.useGravity = false;
            }
        }
        if (isHold)
        {
            
            this.transform.position = new Vector3(PlayerPrefab.transform.position.x, PlayerPrefab.transform.position.y + 1.1f, PlayerPrefab.transform.position.z);

            if (Input.GetKeyDown("e"))
            {
                //プレイヤーの向いている方向を取得
                var Pl_direction = PlayerPrefab.transform.forward;

                //ブロック設置処理
                Pickup_follow obj = Instantiate(this, PlayerPrefab.transform.position + Pl_direction, PlayerPrefab.transform.rotation);

                Destroy(this.gameObject);
                isHold = false;
                rb.useGravity = true;

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
