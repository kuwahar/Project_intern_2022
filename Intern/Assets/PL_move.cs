using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_move : MonoBehaviour
{
    Rigidbody rb;
    private float j_speed;
    private float mv_speed;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        j_speed = 5;
        mv_speed = 1;
        rb = GetComponent<Rigidbody>();
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        if (Input.GetButton("Vertical"))
        {
            Move(Input.GetAxis("Vertical"), "z");      
        }
        if (Input.GetButton("Horizontal"))
        {
            Move(Input.GetAxis("Horizontal"), "x");
        }
        if (Input.GetButton("Horizontal") && Input.GetButton("Horizontal"))
        {
            Move(Input.GetAxis("Horizontal"), "xz", Input.GetAxis("Vertical"));

        }
        if (Input.GetKeyDown("space") && isGround)
        {
            Jump();
        }

    }

    void Move(float vec, string axis, float vec2 = 0) 
    {
        if (axis.Equals("z"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, vec * mv_speed);
        }
        if (axis.Equals("x"))
        {
            rb.velocity = new Vector3(vec * mv_speed, rb.velocity.y, rb.velocity.z);
        }
        if (axis.Equals("xz"))
        {
            rb.velocity = new Vector3(vec * mv_speed, rb.velocity.y, vec2 * mv_speed);
        }

    }

    void Jump()
    {
        //rb.AddForce(new Vector3(0, j_speed, 0));
        rb.velocity = new Vector3(rb.velocity.y, j_speed, rb.velocity.z);
        isGround = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
