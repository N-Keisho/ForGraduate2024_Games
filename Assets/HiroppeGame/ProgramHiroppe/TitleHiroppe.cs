using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// シーンを変える時に追記

public class TitleHiroppe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            SceneManager.LoadScene("HiroppeGame");
        }
    }
    public void OnClick()// ボタンがおされた時の処理　※必ずpublicにします
    {

        SceneManager.LoadScene("HiroppeGame");
    }
}