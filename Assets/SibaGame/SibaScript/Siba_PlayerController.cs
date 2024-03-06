using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siba_PlayerController : MonoBehaviour
{
    [SerializeField] Animator Shiba_PlayerAnim;
    [SerializeField] float moveSpeed1;

    public Siba_GameManager ShibaGM;

    void Update()
    {
        if(!ShibaGM.ShibaisBarrageTimerQuit1)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Shiba_PlayerAnim.SetBool("isPlayerWalking", false);
                Shiba_PlayerAnim.SetBool("isPlayerFighting", true);
            } 
        }
        else
        {
            Shiba_PlayerAnim.SetBool("isPlayerFighting", false);
            PlayerMove(); 
        }
    }
    // PlayerMove 移動とアニメーション
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Shiba_PlayerAnim.SetBool("isPlayerWalking",true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Shiba_PlayerAnim.SetBool("isPlayerWalking", false);
        }

        if (Input.GetKey(KeyCode.M))
        {
            Shiba_PlayerAnim.SetBool("isPlayerAttack",true);
        }
        else if(Input.GetKeyUp(KeyCode.M))
        {
            Shiba_PlayerAnim.SetBool("isPlayerAttack",false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed1 * Time.deltaTime);// 前へ進む
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed1 * Time.deltaTime);// 後ろへ進む
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed1 * Time.deltaTime);// 左へ進む
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed1 * Time.deltaTime);// 右へ進む
        }
    }
}
