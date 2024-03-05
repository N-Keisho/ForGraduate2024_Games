using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siba_SibaController : MonoBehaviour
{
    private Animator Siba_sibaAnim;
    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Siba_sibaAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Siba_sibaAnim.SetBool("isSibaWalking",true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Siba_sibaAnim.SetBool("isSibaWalking", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 前へ進む
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 後ろへ進む
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 左へ進む
        }
        if (Input.GetKey(KeyCode.D))// もしDキーがおされたら
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 右へ進む
        }
    }
}
