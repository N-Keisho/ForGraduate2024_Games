using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siba_PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ShibaPlayer;
    [SerializeField] float speed;

    public Siba_GameManager ShibaGM;


    void Update()
    {
        if(ShibaGM.ShibaisPlayerMove1)
        {
            PlayerMove();
        }
    }

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
}
