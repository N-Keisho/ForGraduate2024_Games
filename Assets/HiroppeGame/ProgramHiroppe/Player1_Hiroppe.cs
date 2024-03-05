using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1_Hiroppe : MonoBehaviour
{

    private Rigidbody rb_hiroppe;
    private float moveSpeed_hiroppe = 10;
    //private float jumpPower_hiroppe = 800;
    //private bool grounded_hiroppe;

    public GameObject bullet_hiroppe;
    private Vector3 force_hiroppe;
    public float bulletSpeed_hiroppe = 5000;

    private GameObject obj;
    private int HP_hiroppe1;
    private int Buki_hiroppe;
    public TextMeshProUGUI P1_hiroppe;
    private int num;
    private Animator anim1;// Animatorを使うための変数
    public bool gameStartHiroppe; //２人とも戦闘開始ボタンをおしたかどうかを判定する
    public int prepare_hiroppe; //戦闘開始ボタンを押された数をカウントする
    public int drunkFlag; //お酒がぶつかった時に左右前後反転するための変数


    // Start is called before the first frame update
    void Start()
    {
        gameStartHiroppe = false;
        rb_hiroppe = GetComponent<Rigidbody>();
        HP_hiroppe1 = 50;
        anim1 = GetComponent<Animator>();// animにAnimatorの値を取得して代入
        prepare_hiroppe = 0;
        drunkFlag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameStartHiroppe); //gameStartHiroppe=2となるとゲームスタート（OKボタンを２人とも押す）

        P1_hiroppe.text = "HP:" + HP_hiroppe1.ToString();

        if (Input.GetKey(KeyCode.W))
        {
            anim1.SetBool("Running1", true);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed_hiroppe * Time.deltaTime * drunkFlag);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim1.SetBool("Running1", true);
            transform.position += transform.TransformDirection(Vector3.back * moveSpeed_hiroppe * Time.deltaTime * drunkFlag);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))// もしWSADキーのいずれかが離されたら、
        {
            anim1.SetBool("Running1", false);// AnimatorのRunningをfalseにする
        }

        //if (Input.GetKeyDown(KeyCode.X)) //今回はジャンプはなくてもいいかも？
        //{
        //    if (grounded_hiroppe == true)
        //    {
        //        rb_hiroppe.AddForce(Vector3.up * jumpPower_hiroppe);
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.X)) //強攻撃
        {
            InputCommand(30, 60, 80);
            StartCoroutine("StrongAttack1_hiroppe");

        }

        if (Input.GetKeyDown(KeyCode.C)) //弱攻撃
        {
            InputCommand(20, 80, 85);
            StartCoroutine("WeakAttack1_hiroppe");
        }

    }

    private void InputCommand(int i1, int i2, int i3)
    {
        //100までの中でランダムの数字を生成してその数字によって何の武器が飛んでいくのかを決める
        int attackNumber = Random.Range(0, 100);
        if (attackNumber > -1 && attackNumber< i1)
        {
            num = 1;
            Attack(num);
        }
        else if (attackNumber < i2)
        {
            num = 2;
            Attack(num);
        }
        else if (attackNumber < i3)
        {
            num = 3;
            Attack(num);
        }
        else
        {
            num = 4;
            Attack(num);
        }

        //GameObject bullets_hiroppe = Instantiate(bullet_hiroppe) as GameObject;
        //bullets_hiroppe.transform.position = this.transform.position;
        //force_hiroppe = this.gameObject.transform.forward * bulletSpeed_hiroppe;
        //bullets_hiroppe.GetComponent<Rigidbody>().AddForce(force_hiroppe);
        //Destroy(bullets_hiroppe.gameObject, 4);
    }

    void Attack(int num)
    {
        //GameObject bullets_hiroppe
        //    = Instantiate(Bukihiroppe.nameList1_hiroppe[num]) as GameObject; //ここ修正必要
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

            //if (collision.gameObject.tag == "Ground_hiroppe")
            //{
            //    grounded_hiroppe = true;
            //}
        }

    private void OnCollisionExit(Collision collision)
        {
            //if (collision.gameObject.tag == "Ground_hiroppe")
            //{
            //    grounded_hiroppe = false;
            //}
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