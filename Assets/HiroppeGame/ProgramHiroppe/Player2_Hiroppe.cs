using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2_Hiroppe : MonoBehaviour
{
    private Rigidbody rb_hiroppe;
    private float moveSpeed_hiroppe = 10;
    private float jumpPower_hiroppe = 800;
    private bool grounded_hiroppe;
    public GameObject bullet_hiroppe;
    private Vector3 force_hiroppe;
    public float bulletSpeed_hiroppe = 5000;


    private int HP_hiroppe2;
    public TextMeshProUGUI P2_hiroppe;
    // Start is called before the first frame update
    void Start()
    {
        rb_hiroppe = GetComponent<Rigidbody>();

        HP_hiroppe2 = 50;
        
    }

    // Update is called once per frame
    void Update()
    {
        P2_hiroppe.text = "HP:" + HP_hiroppe2.ToString();
        
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed_hiroppe * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(new Vector3(0, -2, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += transform.TransformDirection(Vector3.back * moveSpeed_hiroppe * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(new Vector3(0, 2, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded_hiroppe == true)
            {
                rb_hiroppe.AddForce(Vector3.up * jumpPower_hiroppe);
            }
        }

        if (Input.GetKey(KeyCode.O))
        {
            GameObject bullets_hiroppe = Instantiate(bullet_hiroppe) as GameObject;
            bullets_hiroppe.transform.position = this.transform.position;
            force_hiroppe = this.gameObject.transform.forward * bulletSpeed_hiroppe;
            bullets_hiroppe.GetComponent<Rigidbody>().AddForce(force_hiroppe);
            Destroy(bullets_hiroppe.gameObject, 4);
        }
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
}
