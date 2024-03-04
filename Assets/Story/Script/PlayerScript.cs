using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float nomalSpeed = 10.0f;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float jumpPower = 5.0f;
    private Rigidbody rb;
    private bool isGrounded = true;
    public bool moveOK;

    public GameObject hukidasiHiroppe;
    public GameObject hukidasiSiba;
    StoryGameController storyGameController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        storyGameController = GameObject.Find("StoryGameController").GetComponent<StoryGameController>();
        hukidasiHiroppe.SetActive(false);
        hukidasiSiba.SetActive(false);
        moveOK = true;
    }

    void Update()
    {
        if (moveOK)
        {
            move();
        } 
        // Debug.Log(isGrounded);
    }

    private void move(){
        // 前後左右移動
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // ジャンプ
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        // ダッシュ
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = nomalSpeed * 1.5f;
        }else {
            speed = nomalSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NextStage")
        {
            if (!storyGameController.hiroppeClear)
            {
                hukidasiHiroppe.SetActive(true);
            }
            else if (!storyGameController.sibaClear)
            {
                hukidasiSiba.SetActive(true);
            }
            moveOK = false;
            StartCoroutine("rt");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NextStage")
        {
            if (!storyGameController.hiroppeClear)
            {
                hukidasiHiroppe.SetActive(false);
            }
            else if (!storyGameController.sibaClear)
            {
                hukidasiSiba.SetActive(false);
            }
            moveOK = true;
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }

    IEnumerator rt()
    {
        int i = 0;
        while (i < 720)
        {
            i++;
            this.transform.Rotate(0, 0.25f, 0);
            yield return null;
        }

        int j = 0;
        while (j < 100)
        {
            j++;
            this.transform.position += transform.forward * Time.deltaTime;
            yield return null;
        }
    }
}
