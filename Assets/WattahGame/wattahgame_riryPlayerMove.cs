using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wattahgame_riryPlayerMove : MonoBehaviour
{

    private Animator anim; // Animatorの機能を使うための変数
    private wattahgame_ArrowInputRecorder arrowInputRecorder; // wattahgame_ArrowInputRecorder の参照

    private bool isDancing;
    private bool isUpperPosing; // 上キーで動いているかどうかを示すフラグ
    private bool isLeftPosing;
    private bool isRightPosing;
    private bool isDownPosing;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // animにAnimatorの値を代入する
        arrowInputRecorder = FindObjectOfType<wattahgame_ArrowInputRecorder>(); // wattahgame_ArrowInputRecorder のインスタンスを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDancing)
        {
            isDancing = true;
        }


        if (isDancing || Input.GetKeyDown(KeyCode.Joystick2Button3) || Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.Joystick2Button2) || Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            if (arrowInputRecorder != null && arrowInputRecorder.wattahgamecurrentPlayer == 2)
            {
             

                if (Input.GetKeyDown(KeyCode.Joystick2Button3) && !isUpperPosing)
                {
                    anim.SetBool("isDancing", false);
                    anim.SetBool("isUpperPosing", true);
                    isUpperPosing = true;
                    wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
                }
                else if (Input.GetKeyUp(KeyCode.Joystick2Button3))
                {
                    anim.SetBool("isUpperPosing", false);
                    isUpperPosing = false;
                    
                }

                else if (Input.GetKeyDown(KeyCode.Joystick2Button2) && !isLeftPosing)
                {
                    anim.SetBool("isDancing", false);
                    anim.SetBool("isLeftPosing", true);
                    isLeftPosing = true;
                    wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
                }
                else if (Input.GetKeyUp(KeyCode.Joystick2Button2))
                {
                    anim.SetBool("isLeftPosing", false);
                    isLeftPosing = false;
                }

                else if (Input.GetKeyDown(KeyCode.Joystick2Button1) && !isRightPosing)
                {
                    anim.SetBool("isDancing", false);
                    anim.SetBool("isRightPosing", true);
                    isRightPosing = true;
                    wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
                }
                else if (Input.GetKeyUp(KeyCode.Joystick2Button1))
                {
                    anim.SetBool("isRightPosing", false);
                    isRightPosing = false;
                }

                else if (Input.GetKeyDown(KeyCode.Joystick2Button0) && !isDownPosing)
                {
                    anim.SetBool("isDancing", false);
                    anim.SetBool("isDownPosing", true);
                    isDownPosing = true;
                    wattahgame_SoundManager.Instance.PlaySE(wattahgameSESoundData.SE.Pose);
                }
                else if (Input.GetKeyUp(KeyCode.Joystick2Button0))
                {
                    anim.SetBool("isDownPosing", false);
                    isDownPosing = false;
                }
            }

        }

        if (isDancing)
        {
            anim.SetBool("isDancing", true);
            isUpperPosing = false;
            isLeftPosing = false;
            isRightPosing = false;
            isDownPosing = false;
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button0)) Debug.Log("test_1");  //Right
        if(Input.GetKeyDown(KeyCode.Joystick2Button0)) Debug.Log("test_2");  //Left
        
    }
}
