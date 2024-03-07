using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1_Hiroppe : MonoBehaviour
{
    public ParamsSOhiroppe[] paramsSOhiroppes;

    private Rigidbody rb_hiroppe;
    private float moveSpeed_hiroppe = 20;
    private float jumpPower_hiroppe = 800;
    private bool grounded_hiroppe;

    public GameObject bullet_hiroppe;
    private Vector3 force_hiroppe;
    public float bulletSpeed_hiroppe = 5000;

    private GameObject obj;
    public int HP_hiroppe1;
    private int Buki_hiroppe;
    public TextMeshProUGUI P1_hiroppe;
    public int numhiro1;
    private Animator anim1;// Animatorを使うための変数
    public bool gameStartHiroppe; //２人とも戦闘開始ボタンをおしたかどうかを判定する
    public int prepare_hiroppe; //戦闘開始ボタンを押された数をカウントする

    private float movementInputValue;
    private float turnInputValue;
    private bool reverse = false;


    // Start is called before the first frame update
    void Start()
    {
        gameStartHiroppe = false;
        rb_hiroppe = GetComponent<Rigidbody>();
        HP_hiroppe1 = 50;
        anim1 = GetComponent<Animator>();// animにAnimatorの値を取得して代入
        prepare_hiroppe = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        if (gameStartHiroppe == true)
        {
            Player2_Hiroppe ph2
                = GameObject.Find("Player2_Hiroppe").GetComponent<Player2_Hiroppe>();
            if (ph2.gameStartHiroppe1 == true)
            {

                P1_hiroppe.text = "HP:" + HP_hiroppe1.ToString();

                if (Input.GetKey(KeyCode.W))
                {
                    anim1.SetBool("Running1", true);
                    transform.position += transform.TransformDirection(Vector3.forward * moveSpeed_hiroppe * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(new Vector3(0, -1, 0));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    anim1.SetBool("Running1", true);
                    transform.position += transform.TransformDirection(Vector3.back * moveSpeed_hiroppe * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(new Vector3(0, 1, 0));
                }

                if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.Joystick2Button10))// もしWSADキーのいずれかが離されたら、
                {
                    anim1.SetBool("Running1", false);// AnimatorのRunningをfalseにする
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Joystick2Button3)) //今回はジャンプはなくてもいいかも？
                {
                    if (grounded_hiroppe == true)
                    {
                        rb_hiroppe.AddForce(Vector3.up * jumpPower_hiroppe);
                    }
                }

                if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick2Button0) )//強攻撃
                {
                    InputCommand(30, 60, 80);
                    StartCoroutine("StrongAttack1_hiroppe");

                }

                if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Joystick2Button2)) //弱攻撃
                {
                    InputCommand(20, 80, 85);
                    StartCoroutine("WeakAttack1_hiroppe");
                }
                PlayerMove();
            }
        }
        //Debug.Log(gameStartHiroppe); //gameStartHiroppe=2となるとゲームスタート（OKボタンを２人とも押す）


    }
    void PlayerMove()
    {
        if (reverse == false)
        {
            movementInputValue = Input.GetAxis("Vertical2");
            Vector3 movement = transform.forward * movementInputValue * 30 * Time.deltaTime;
            rb_hiroppe.MovePosition(rb_hiroppe.position + movement);

            turnInputValue = Input.GetAxis("Horizontal2");
            float turn = turnInputValue * 100 * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rb_hiroppe.MoveRotation(rb_hiroppe.rotation * turnRotation);
        }
        else
        {
            movementInputValue = Input.GetAxis("Vertical2-2");
            Vector3 movement = transform.forward * movementInputValue * 30 * Time.deltaTime;
            rb_hiroppe.MovePosition(rb_hiroppe.position + movement);

            turnInputValue = Input.GetAxis("Horizontal2-2");
            float turn = turnInputValue * 100 * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rb_hiroppe.MoveRotation(rb_hiroppe.rotation * turnRotation);
            Invoke("reverse_data", 10f);
        }

       

        if (movementInputValue == 1 || movementInputValue == -1)
        {
            anim1.SetBool("Running1", true);
        }
        else
        {
            anim1.SetBool("Running1", false);
        }
        
    }
    private void reverse_data()
    {
        reverse = false;
    }

    private void InputCommand(int i1, int i2, int i3)
    {
        // //100までの中でランダムの数字を生成してその数字によって何の武器が飛んでいくのかを決める
        int attarckNumber = Random.Range(0, 100);

        if(attarckNumber > -1 && attarckNumber <i1)
        {
            numhiro1 = 0;
            Attack(numhiro1);
        }
        else if(attarckNumber < i2)
        {
            numhiro1 = 1;
            Attack(numhiro1);
        }
        else if (attarckNumber < i3)
        {
            numhiro1 = 2;
            Attack(numhiro1);
        }
        else
        {
            numhiro1 = 3;
            Attack(numhiro1);
            
        }
 
    }

    void Attack(int numhiro1)
    {
        GameObject bullets_hiroppe = Instantiate(paramsSOhiroppes[numhiro1].item_hiroppe) as GameObject;
        if (numhiro1 == 0)
        {
            bullets_hiroppe.tag = "P1Beer_hiroppe";
        }
        else
        {
            bullets_hiroppe.tag = "P1Bullet_hiroppe";
        }

        bullets_hiroppe.transform.position = this.transform.position;
        force_hiroppe = this.gameObject.transform.forward * bulletSpeed_hiroppe;
        bullets_hiroppe.GetComponent<Rigidbody>().AddForce(force_hiroppe);
        Destroy(bullets_hiroppe.gameObject, 4);


    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground_Hiroppe")
        {
            grounded_hiroppe = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground_Hiroppe")
        {
            grounded_hiroppe = false;
        }
    }

    void OnTriggerEnter(Collider collision) {
        if (0 < HP_hiroppe1){
            if (collision.gameObject.tag == "P2Bullet_hiroppe")
            {
                Player2_Hiroppe p2h = GameObject.Find("Player2_Hiroppe").GetComponent<Player2_Hiroppe>();
                HP_hiroppe1 += p2h.paramsSOhiroppes2[p2h.numhiro2].damage_hiroppe;
            }
            else if (collision.gameObject.tag == "P2Beer_hiroppe")
            {
                Player2_Hiroppe p2h = GameObject.Find("Player2_Hiroppe").GetComponent<Player2_Hiroppe>();
                HP_hiroppe1 += p2h.paramsSOhiroppes2[p2h.numhiro2].damage_hiroppe;
                reverse = true;
            }
        }

    }

    IEnumerator StrongAttack1_hiroppe()
        {
            yield return new WaitForSeconds(0.2f);
            anim1.SetBool("StAttack1", true);
            yield return new WaitForSeconds(1.4f);
            anim1.SetBool("StAttack1", false);

            yield break;
        }

    IEnumerator WeakAttack1_hiroppe()
        {
            yield return new WaitForSeconds(0.1f);
            anim1.SetBool("WeAttack1", true);
            yield return new WaitForSeconds(1);
            anim1.SetBool("WeAttack1", false);

            yield break;
        }
}