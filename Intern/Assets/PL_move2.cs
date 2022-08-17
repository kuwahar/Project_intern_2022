using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PL_move2 : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float j_speed = 5;  //飛ぶ速度

    [SerializeField]
    private float mv_speed = 3; //移動速度

    private bool isGround;  //設置判定
    private bool isFixed;   //キャラが固定されてるかどうか
    float inputHorizontal;
    float inputVertical;

    public List<GameObject> CarryBlockList = new List<GameObject>();
    private float dis;
    private Vector3 posB;
    private Vector3 posP;
    [SerializeField]
    private bool isHold = false;
    [SerializeField]
    private bool isPickable = true;
    [SerializeField]
    private float timer = 0;
    private float rayDistance;
    private Pickup_follow pickup_Follow;


    //なんのブロックを持っているのか
    //

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGround = true;
        isFixed = false;
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = transform.forward;
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical"); 
        rb.useGravity = true;

        if (Input.GetKeyDown("space") && isGround)
        {
            Jump();
        }
        Pick();
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
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

        isFixed = false;
    }

    void Jump()
    {
        //rb.AddForce(new Vector3(0, j_speed, 0));
        rb.velocity = new Vector3(rb.velocity.y, j_speed, rb.velocity.z);
        isGround = false;
    }

    void Pick()
    {
        var direction = this.transform.forward;

        var PickableBlock =CarryBlockList.Where(x => Dist(x.transform.position, this.transform.position)).FirstOrDefault();
          //posB = CarryBlock.transform.position; //blockの座標
          //posP = this.transform.position; //プレイヤーの座標

            if (!isHold)
            {
                if (Input.GetKeyDown(KeyCode.E))
                //if (Input.GetKeyDown(KeyCode.E) && isPickable)
                {
                    isHold = true;
                    //rb.useGravity = false;
                    isPickable = false;
                }
            }
        
        if (isHold)
        {
            //ブロック持ち上げ
            PickableBlock.transform.position = new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z);

            if (Input.GetKeyDown(KeyCode.E) && isPickable)
            //if (Input.GetKeyDown(KeyCode.F))
                {
                //プレイヤーの向いている方向を取得
                var Pl_direction = transform.forward;


                //ブロック設置処理　Instantiateは使わないほうがいい
                PickableBlock.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + Pl_direction;
                isHold = false;
                //rb.useGravity = true;
                isPickable = false;

            }
        }
        
        if (!isPickable)
        {
            //isPickableがfalseなら、直前のフレームからの経過時間を足す
                timer += Time.deltaTime;

                //timerが1秒を越えたら、isAttackableをtrueに戻して
                //次に備えて、timerを0で初期化
                if (timer >= 1)
                {
                    isPickable = true;
                    timer = 0.0f;
                }
        }
        
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
