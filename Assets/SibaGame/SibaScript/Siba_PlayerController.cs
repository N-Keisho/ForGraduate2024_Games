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
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                Shiba_PlayerAnim.SetBool("isPlayerWalking", false);
                Shiba_PlayerAnim.SetBool("isPlayerFighting", true);
            } 
        }
        else
        {
            Shiba_PlayerAnim.SetBool("isPlayerFighting", false);
            if (Input.GetKey(KeyCode.Joystick1Button1))//xボタン
            {
                Shiba_PlayerAnim.SetBool("isPlayerAttack",true);
            }
            else if(Input.GetKeyUp(KeyCode.Joystick1Button1))//xボタン
            {   
                Shiba_PlayerAnim.SetBool("isPlayerAttack",false);
            }
            // Joyconのスティックの入力を取得
            float horizontal_1 = Input.GetAxis("Horizontal_3");
            float vertical_1 = Input.GetAxis("Vertical_3");
            // メモ$は、文字列中に変数の値を埋め込むための簡単な方法
            Debug.Log($"Horizontal_1: {horizontal_1}, Vertical_1: {vertical_1}");

            // スティックの入力があるかどうかを判断
            if (Mathf.Abs(horizontal_1) > 0.1f || Mathf.Abs(vertical_1) > 0.1f)
            {
                Shiba_PlayerAnim.SetBool("isPlayerWalking", true);
            }
            else
            {
                Shiba_PlayerAnim.SetBool("isPlayerWalking", false);
            }

            // ここでスティックの入力に基づいて移動などを制御する
            // ベクトル化
            Vector3 moveDirection = new Vector3(-horizontal_1, 0, vertical_1).normalized;
            if (moveDirection.magnitude > 0.1f)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 500);
                transform.Translate(Vector3.forward * moveSpeed1 * Time.deltaTime);
            }
        }
    }
}
