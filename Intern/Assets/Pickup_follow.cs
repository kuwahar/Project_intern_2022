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
    private bool isHold;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isHold = true;

    }

    // Update is called once per frame
    void Update()
    {
        //posB = this.transform.position;
        //posP = Player.transform.position;

        //if (Dist(posB, posP) && isHold)
        //{
        if (isHold)
        {
            this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z);
        }
        // }
    }

    bool Dist(Vector3 pos1, Vector3 pos2)
    {
        dis = Vector3.Distance(pos1, pos2);
        if (dis < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
