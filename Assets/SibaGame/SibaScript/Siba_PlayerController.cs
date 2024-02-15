using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siba_PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ShibaPlayer;
    [SerializeField] Animator ShibaPLayerAnim;
    [SerializeField] float speed;

    public Siba_GameManager ShibaGM;


    void Update()
    {
        if(ShibaGM.ShibaisPlayerMove1)
        {
            PlayerMove();
            ShibaPLayerAnim.SetBool("Swing_bool",false);
        }
        else
        {
            BarrageMove();
        }
    }
    // PlayerMove 移動とアニメーション
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ShibaPlayer.transform.position += speed * transform.forward * Time.deltaTime;
        }
        // Sキー（後方移動）
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ShibaPlayer.transform.position -= speed * transform.forward * Time.deltaTime;
        }
        // Dキー（右移動）
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ShibaPlayer.transform.position += speed * transform.right * Time.deltaTime;
        }
        // Aキー（左移動）
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ShibaPlayer.transform.position -= speed * transform.right * Time.deltaTime;
        }
    }
    // BarrageMove 連打の時のアニメーション
    void BarrageMove()
    {
        float Horizontalvalue;
        Horizontalvalue = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal" + Horizontalvalue);
        if (Horizontalvalue  > 0.0f || Horizontalvalue < 0.0f)
        {
            ShibaPLayerAnim.SetBool("Swing_bool",true);
        }
        else
        {
            ShibaPLayerAnim.SetBool("Swing_bool",false);
        }
    }
}
