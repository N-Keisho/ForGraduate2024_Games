using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// シーンを変える時に追記

public class NextHiroppe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        SceneManager.LoadScene("HiroppeGame"); //ここメインストーリーと接続するする
    }
}
