using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2_Hiroppe : MonoBehaviour
{
    public ParamsSOhiroppe[] paramsSOhiroppes2;
    private Rigidbody rb_hiroppe;
    private float moveSpeed_hiroppe = 20;
    private float jumpPower_hiroppe = 80;
    private bool grounded_hiroppe;
    public GameObject bullet_hiroppe;
    private Vector3 force_hiroppe;
    public float bulletSpeed_hiroppe = 5000;
    private Animator anim2;// Animatorを使うための変数

    public int numhiro2;
    public int HP_hiroppe2;
    public TextMeshProUGUI P2_hiroppe;

    public bool gameStartHiroppe1;
     public int prepare_hiroppe1;

    private float movementInputValue;
    private float turnInputValue;

    private bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        gameStartHiroppe1 = false;
        rb_hiroppe = GetComponent<Rigidbody>();
        HP_hiroppe2 = 50;
        anim2 = GetComponent<Animator>();// animにAnimatorの値を取得して代入
        prepare_hiroppe1 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStartHiroppe1 == true)
        { 
            Player1_Hiroppe ph1
                = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
            if (ph1.gameStartHiroppe == true)
            {
                P2_hiroppe.text = "HP:" + HP_hiroppe2.ToString();
        
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += transform.TransformDirection(Vector3.forward * moveSpeed_hiroppe * Time.deltaTime);
                    anim2.SetBool("Walk2", true);
                    //anim2.SetBool("Running2", true);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(new Vector3(0, -1, 0));
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position += transform.TransformDirection(Vector3.back * moveSpeed_hiroppe * Time.deltaTime);
                    anim2.SetBool("Walk2", true);
                    //anim2.SetBool("Running2", true);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(new Vector3(0, 1, 0));
                }

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button3))
                {
                    if (grounded_hiroppe == true)
                    {
                        rb_hiroppe.AddForce(Vector3.up * jumpPower_hiroppe);
                    }
                }

                if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Joystick1Button11))// もしWSADキーのいずれかが離されたら、
                {
                    anim2.SetBool("Running2", false);// AnimatorのRunningをfalseにする
                }

                if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.Joystick1Button0)) //強攻撃
                {
                    InputCommand(40, 60, 80);
                    StartCoroutine("StrongAttack2_hiroppe");

                }

                if (Input.GetKeyDown(KeyCode.L) || Input.GetKey(KeyCode.Joystick1Button2)) //弱攻撃
                {
                    InputCommand(30, 90, 100);
                    StartCoroutine("WeakAttack2_hiroppe");
                }

                //if (Input.GetKeyUp(KeyCode.O))// もし、Cキーが離されたら、
                //{
                //    anim2.SetBool("WeAttack2", false);// Attackをfalseにする
                //    anim2.SetBool("StAttack2", false);// Attackをfalseにする
                //}

                if (HP_hiroppe2 <= 0)
                {
                    anim2.SetBool("Dying2", true);
                }
                PlayerMove();
            }
        }
        
    }

    void PlayerMove()
    {
        if (reverse == false)
        {
            movementInputValue = Input.GetAxis("Vertical1");
            Vector3 movement = transform.forward * movementInputValue * 30 * Time.deltaTime;
            rb_hiroppe.MovePosition(rb_hiroppe.position + movement);
        }
        else
        {
            movementInputValue = Input.GetAxis("Vertical1-2");
            Vector3 movement = transform.forward * movementInputValue * 30 * Time.deltaTime;
            rb_hiroppe.MovePosition(rb_hiroppe.position + movement);
            Invoke("reverse_data", 50f);
        }

        turnInputValue = Input.GetAxis("Horizontal1");
        float turn = turnInputValue * 100 * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb_hiroppe.MoveRotation(rb_hiroppe.rotation * turnRotation);

         if (movementInputValue == 1 || movementInputValue == -1)
        {
            anim2.SetBool("Walk2", true);
        }
        else
        {
            anim2.SetBool("Walk2", false);
        }
    }
    private void reverse_data()
    {
        reverse = false;
    }

    private void InputCommand(int i1, int i2, int i3)
    {
        //100までの中でランダムの数字を生成してその数字によって何の武器が飛んでいくのかを決める
        int attackNumber = Random.Range(0, 100);
        if (attackNumber > -1 && attackNumber < i1)
        {
            numhiro2 = 0;
            Attack(numhiro2);
        }
        else if (attackNumber < i2)
        {
            numhiro2 = 1;
            Attack(numhiro2);
        }
        else if (attackNumber < i3)
        {
            numhiro2 = 2;
            Attack(numhiro2);
        }
        else
        {
            numhiro2 = 3;
            Attack(numhiro2);
        }
    }

    void Attack(int numhiro2)
    {
        GameObject bullets_hiroppe = Instantiate(paramsSOhiroppes2[numhiro2].item_hiroppe) as GameObject;

        if (numhiro2 == 0)
        {
            bullets_hiroppe.tag = "P2Beer_hiroppe";
        }
        else
        {
            bullets_hiroppe.tag = "P2Bullet_hiroppe";
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
        if (0 < HP_hiroppe2){
            if (collision.gameObject.tag == "P1Bullet_hiroppe")
            {
                Player1_Hiroppe p1h = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
                HP_hiroppe2 += p1h.paramsSOhiroppes[p1h.numhiro1].damage_hiroppe;
            }
            else if (collision.gameObject.tag == "P1Beer_hiroppe")
            {
                Player1_Hiroppe p1h = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
                HP_hiroppe2 += p1h.paramsSOhiroppes[p1h.numhiro1].damage_hiroppe;
                reverse = true;

            }
        
        }
    }

    IEnumerator StrongAttack2_hiroppe() //X
    {
        yield return new WaitForSeconds(0.2f);
        anim2.SetBool("StAttack2", true);
        yield return new WaitForSeconds(1.2f);
        anim2.SetBool("StAttack2", false);

        yield break;
    }

    IEnumerator WeakAttack2_hiroppe() //C
    {
        yield return new WaitForSeconds(0.1f);
        anim2.SetBool("WeAttack2", true);
        yield return new WaitForSeconds(0.5f);
        anim2.SetBool("WeAttack2", false);

        yield break;
    }
}
