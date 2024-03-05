using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wattahgame_WattahPlayerMove : MonoBehaviour
{

    private Animator anim; // Animatorの機能を使うための変数

    private bool isDancing;
    private bool isUpperPosing; // 上キーで動いているかどうかを示すフラグ
    private bool isLeftPosing;
    private bool isRightPosing;
    private bool isDownPosing;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // animにAnimatorの値を代入する
        isDancing = false;
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDancing && Time.time - startTime > 1f)
        {
            isDancing = true;
        }

        if (isDancing)
        {
            anim.SetBool("isDancing", true);
            isUpperPosing = false;
            isLeftPosing = false;
            isRightPosing = false;
            isDownPosing = false;
        }

        if (isDancing || Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (Input.GetKeyDown(KeyCode.UpArrow) && !isUpperPosing)
            {
                anim.SetBool("isDancing", false);
                anim.SetBool("isUpperPosing", true);
                isUpperPosing = true;
                wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetBool("isUpperPosing", false);
                isUpperPosing = false;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isLeftPosing)
            {
                anim.SetBool("isDancing", false);
                anim.SetBool("isLeftPosing", true);
                isLeftPosing = true;
                wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("isLeftPosing", false);
                isLeftPosing = false;
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow) && !isRightPosing)
            {
                anim.SetBool("isDancing", false);
                anim.SetBool("isRightPosing", true);
                isRightPosing = true;
                wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("isRightPosing", false);
                isRightPosing = false;
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow) && !isDownPosing)
            {
                anim.SetBool("isDancing", false);
                anim.SetBool("isDownPosing", true);
                isDownPosing = true;
                wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("isDownPosing", false);
                isDownPosing = false;
            }

        }

        if(Input.GetKeyDown(KeyCode.Joystick2Button0)) Debug.Log("test_Right");  //Right
        if(Input.GetKeyDown(KeyCode.Joystick3Button0)) Debug.Log("test_Left");  //Left
        
    }
}
