using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PL_move2 : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float j_speed = 5;  //��ԑ��x

    [SerializeField]
    private float mv_speed = 3; //�ړ����x

    public bool isGround;  //�ݒu����
    private bool isFixed;   //�L�������Œ肳��Ă邩�ǂ���
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
    private GameObject Pickup_Block = null;

    public GameObject Star = null;

    //private Pickup_follow Pickup_Block;


    //�Ȃ�̃u���b�N�������Ă���̂�
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
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        if (!isFixed)
            rb.velocity = moveForward * mv_speed + new Vector3(0, rb.velocity.y, 0);

        // �L�����N�^�[�̌�����i�s������
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


        if (!isHold) Pickup_Block =CarryBlockList.Where(x => Dist(x.transform.position, this.transform.position)).FirstOrDefault();
        //posB = CarryBlock.transform.position; //block�̍��W
        //posP = this.transform.position; //�v���C���[�̍��W
        
        if (Pickup_Block != null)
        {
            var obj_rb = Pickup_Block.GetComponent<Rigidbody>();

            if (!isHold)
            {
                if (Input.GetKeyDown(KeyCode.E))
                //if (Input.GetKeyDown(KeyCode.E) && isPickable)
                {
                    isHold = true;
                    obj_rb.useGravity = false;
                    isPickable = false;
                }
            }

            if (isHold)
            {
                //�u���b�N�����グ
                Pickup_Block.transform.position = new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z);

                if (Input.GetKeyDown(KeyCode.E) && isPickable)
                //if (Input.GetKeyDown(KeyCode.F))
                {
                    //�v���C���[�̌����Ă���������擾
                    var Pl_direction = transform.forward;


                    //�u���b�N�ݒu�����@Instantiate�͎g��Ȃ��ق�������
                    Pickup_Block.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + Pl_direction;
                    isHold = false;
                    obj_rb.useGravity = true;
                    isPickable = false;

                }
            }

            if (!isPickable)
            {
                //isPickable��false�Ȃ�A���O�̃t���[������̌o�ߎ��Ԃ𑫂�
                timer += Time.deltaTime;

                //timer��1�b���z������AisAttackable��true�ɖ߂���
                //���ɔ����āAtimer��0�ŏ�����
                if (timer >= 1)
                {
                    isPickable = true;
                    timer = 0.0f;
                }
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
            var star = GameObject.Find("Star").GetComponent<Get>();
            star.isStarGot = true;
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
