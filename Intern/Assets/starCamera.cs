using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starCamera : MonoBehaviour
{
    Get star;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        star = GameObject.Find("Star").GetComponent<Get>();
        if (star.isStarGot)
        {
            GetComponent<Camera>().depth = 1;

            transform.position += new Vector3(0, 1, 10);
        }
    }
}
