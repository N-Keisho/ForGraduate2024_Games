using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Siba_GameStart : MonoBehaviour
{
    bool SibaStart1,SibaStart2;
    float SibaStartTimer;
    [SerializeField]GameObject Howto1, Howto2;
    // Start is called before the first frame update
    void Start()
    {
        SibaStart1 = false;
        SibaStart2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        SibaStartTimer +=Time.deltaTime;//時間を増やす
        if(SibaStartTimer >= 1.0f)//1秒以上経てばOK
        {
            if(Input.GetMouseButtonDown(0)){
                if(!SibaStart1 && !SibaStart2){
                    SibaStart1=true;
                    Howto1.SetActive(false);
                    Howto2.SetActive(true);
                }
                else if (SibaStart1 && !SibaStart2){
                    SibaStart2 = true;
                    SceneManager.LoadScene("SibaGame");
                }
            }
        }
    }
}
