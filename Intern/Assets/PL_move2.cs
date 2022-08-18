using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PL_move2 : MonoBehaviour
{
    
    Rigidbody rb;
    private CharacterController characterController;

    [SerializeField]
    private float walkSpeed;
    private Animator animator;

    [SerializeField]
    private float j_speed = 5;  //飛ぶ速度

    [SerializeField]
    private float mv_speed = 3; //移動速度

    private bool isGround;  //設置判定
    private bool isFixed;   //キャラが固定されてるかどうか
    float inputHorizontal;
    float inputVertical;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGround = true;
        isFixed = false;

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("space") && isGround)
        {
            Jump();
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isFixed = true;
        }
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        if (!isFixed)
            rb.velocity = moveForward * mv_speed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            animator.SetFloat("walkstate", 1);
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        else
        {
            animator.SetFloat("walkstate", 0);
        }

        if(isGround != true)
        {
            animator.SetFloat("jumpstate", 1);
        }

        isFixed = false;
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
            animator.SetFloat("jumpstate", 0);
        }

        if (other.gameObject.tag == "Star")
        {
            SceneManager.LoadScene("result");
        }

    }
}
