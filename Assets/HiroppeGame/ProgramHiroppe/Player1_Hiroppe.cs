using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1_Hiroppe : MonoBehaviour
{

    private Rigidbody rb_hiroppe;
    private float moveSpeed_hiroppe = 10;
    private float jumpPower_hiroppe = 800;
    private bool grounded_hiroppe;

    public GameObject bullet_hiroppe;
    private Vector3 force_hiroppe;
    public float bulletSpeed_hiroppe = 5000;

    private GameObject obj;
    private int HP_hiroppe1;
    //private int Buki_hiroppe;
    public TextMeshProUGUI P1_hiroppe;
    private int num;
    private Animator anim1;// Animatorを使うための変数


    // Start is called before the first frame update
    void Start()
    {
        rb_hiroppe = GetComponent<Rigidbody>();
        HP_hiroppe1 = 50;
        anim1 = GetComponent<Animator>();// animにAnimatorの値を取得して代入
    }

    // Update is called once per frame
    void Update()
    {
        P1_hiroppe.text = "HP:" + HP_hiroppe1.ToString();

        if (Input.GetKey(KeyCode.W))
        {
            anim1.SetBool("Running1", true);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed_hiroppe * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -2, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim1.SetBool("Running1", true);
            transform.position += transform.TransformDirection(Vector3.back * moveSpeed_hiroppe * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 2, 0));
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))// もしWSADキーのいずれかが離されたら、
        {
            anim1.SetBool("Running1", false);// AnimatorのRunningをfalseにする
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (grounded_hiroppe == true)
            {
                rb_hiroppe.AddForce(Vector3.up * jumpPower_hiroppe);
            }
        }

        if (Input.GetKey(KeyCode.C))
        {
            //100までの中でランダムの数字を生成してその数字によって何の武器が飛んでいくのかを決める
            int attackNumber = Random.Range(0, 100);
            if(attackNumber > -1 && attackNumber < 20)
            {
                num = 1;
                Attack(num);
                anim1.SetBool("WeAttack1", true);// AnimatorのAttackをtrueにする
            }
            else if(attackNumber < 40)
            {
                num = 2;
                Attack(num);
                anim1.SetBool("WeAttack1", true);// AnimatorのAttackをtrueにする
            }
            else if (attackNumber < 50)
            {
                num = 3;
                Attack(num);
                anim1.SetBool("WeAttack1", true);// AnimatorのAttackをtrueにする
            }
            else
            {
                num = 4;
                Attack(num);
                anim1.SetBool("StAttack1", true);// AnimatorのAttackをtrueにする
            }

            //GameObject bullets_hiroppe = Instantiate(bullet_hiroppe) as GameObject;
            //bullets_hiroppe.transform.position = this.transform.position;
            //force_hiroppe = this.gameObject.transform.forward * bulletSpeed_hiroppe;
            //bullets_hiroppe.GetComponent<Rigidbody>().AddForce(force_hiroppe);
            //Destroy(bullets_hiroppe.gameObject, 4);
        }

        if (Input.GetKeyUp(KeyCode.C))// もし、Cキーが離されたら、
        {
            anim1.SetBool("WeAttack1", false);// Attackをfalseにする
            anim1.SetBool("StAttack1", false);// Attackをfalseにする
        }

        if(HP_hiroppe1 <= 0)
        {
            anim1.SetBool("Dying1", true);
        }
            
    }

    private void Attack(int num)
    {
        //GameObject bullets_hiroppe
        //    = Instantiate(BukiList_Hiroppe.nameList1_hiroppe[num]) as GameObject;
        //bullets_hiroppe.transform.position = this.transform.position;
        //force_hiroppe = this.gameObject.transform.forward * bulletSpeed_hiroppe;
        //bullets_hiroppe.GetComponent<Rigidbody>().AddForce(force_hiroppe);
        //Destroy(bullets_hiroppe.gameObject, 4);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "P2Bullet_hiroppe")
        {
            HP_hiroppe1 += 1;

        }

        if (collision.gameObject.tag == "Ground_hiroppe")
        {
            grounded_hiroppe = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground_hiroppe")
        {
            grounded_hiroppe = false;
        }
    }
}
