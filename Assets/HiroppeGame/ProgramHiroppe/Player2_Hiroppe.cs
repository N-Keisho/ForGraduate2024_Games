using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2_Hiroppe : MonoBehaviour
{
    private Rigidbody rb_hiroppe;
    private float moveSpeed_hiroppe = 20;
    private float jumpPower_hiroppe = 800;
    private bool grounded_hiroppe;
    public GameObject bullet_hiroppe;
    private Vector3 force_hiroppe;
    public float bulletSpeed_hiroppe = 5000;
    private Animator anim2;// Animatorを使うための変数

    private int num;
    private int HP_hiroppe2;
    public TextMeshProUGUI P2_hiroppe;
    // Start is called before the first frame update
    void Start()
    {
        rb_hiroppe = GetComponent<Rigidbody>();
        HP_hiroppe2 = 50;
        anim2 = GetComponent<Animator>();// animにAnimatorの値を取得して代入

    }

    // Update is called once per frame
    void Update()
    {
        P2_hiroppe.text = "HP:" + HP_hiroppe2.ToString();
        
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed_hiroppe * Time.deltaTime);
            anim2.SetBool("Walk2", true);
            //anim2.SetBool("Running2", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += transform.TransformDirection(Vector3.back * moveSpeed_hiroppe * Time.deltaTime);
            anim2.SetBool("Walk2", true);
            //anim2.SetBool("Running2", true);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(new Vector3(0, 1, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded_hiroppe == true)
            {
                rb_hiroppe.AddForce(Vector3.up * jumpPower_hiroppe);
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))// もしWSADキーのいずれかが離されたら、
        {
            anim2.SetBool("Walk2", false);
            anim2.SetBool("Running2", false);// AnimatorのRunningをfalseにする
        }

        if (Input.GetKeyDown(KeyCode.X)) //強攻撃
        {
            InputCommand(40, 60, 80);
            StartCoroutine("StrongAttack2_hiroppe");

        }

        if (Input.GetKeyDown(KeyCode.C)) //弱攻撃
        {
            InputCommand(30, 90, 100);
            StartCoroutine("WeakAttack2_hiroppe");
        }

        //if (Input.GetKey(KeyCode.O))
        //{
        //    GameObject bullets_hiroppe = Instantiate(bullet_hiroppe) as GameObject;
        //    bullets_hiroppe.transform.position = this.transform.position;
        //    force_hiroppe = this.gameObject.transform.forward * bulletSpeed_hiroppe;
        //    bullets_hiroppe.GetComponent<Rigidbody>().AddForce(force_hiroppe);
        //    Destroy(bullets_hiroppe.gameObject, 4);
        //}

        if (Input.GetKeyUp(KeyCode.O))// もし、Cキーが離されたら、
        {
            anim2.SetBool("WeAttack2", false);// Attackをfalseにする
            anim2.SetBool("StAttack2", false);// Attackをfalseにする
        }

        if (HP_hiroppe2 <= 0)
        {
            anim2.SetBool("Dying2", true);
        }
    }

    private void InputCommand(int i1, int i2, int i3)
    {
        //100までの中でランダムの数字を生成してその数字によって何の武器が飛んでいくのかを決める
        int attackNumber = Random.Range(0, 100);
        if (attackNumber > -1 && attackNumber < i1)
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

    
        if (collision.gameObject.tag == "P1Bullet_hiroppe")
        {
            HP_hiroppe2 -= 1;
        
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
