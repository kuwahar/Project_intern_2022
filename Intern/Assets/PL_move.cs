using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PL_move : MonoBehaviour
{
    Rigidbody rb;
    private float j_speed;  //飛ぶ速度
    private float mv_speed; //移動速度
    private bool isGround;  //設置判定
    private bool isFixed;   //キャラが固定されてるかどうか


    // Start is called before the first frame update
    void Start()
    {
        j_speed = 5;
        mv_speed = 3;
        rb = GetComponent<Rigidbody>();
        isGround = true;
        isFixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isFixed = true;
        }

        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        if ((Input.GetButton("Vertical")) ^ (Input.GetButton("Horizontal")))
        {
            if (Input.GetButton("Vertical"))
            {
                Move(Input.GetAxis("Vertical"), "z");
            }
            if (Input.GetButton("Horizontal"))
            {
                Move(Input.GetAxis("Horizontal"), "x");
            }

        }
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            Move(Input.GetAxis("Horizontal"), "xz", Input.GetAxis("Vertical"));

        }

        if (Input.GetKeyDown("space") && isGround)
        {
            Jump();
        }
        isFixed = false;


    }

    void Move(float vec, string axis, float vec2 = 0)
    {
        Transform myTransform = this.transform;

        Vector3 worldAngle = myTransform.localEulerAngles;

        if (axis.Equals("z"))
        {
            if (!isFixed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, vec * mv_speed);
            }
            worldAngle.y = vec * 180.0f; 
        }
        if (axis.Equals("x"))
        {
            if (!isFixed)
            {
                rb.velocity = new Vector3(vec * mv_speed, rb.velocity.y, rb.velocity.z);
            }
            worldAngle.y = vec * 90.0f; 
        }
        if (axis.Equals("xz"))
        {
            if (!isFixed)
            {
                rb.velocity = new Vector3(vec * mv_speed, rb.velocity.y, vec2 * mv_speed);
            }
            worldAngle.y = (vec * vec2) * 45.0f; 

        }
        myTransform.localEulerAngles = worldAngle; // 回転角度を設定
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

        if (other.gameObject.tag == "Star")
        {
            SceneManager.LoadScene("result");
        }

    }
}
