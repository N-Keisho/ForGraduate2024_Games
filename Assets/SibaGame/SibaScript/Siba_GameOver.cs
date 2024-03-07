using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Siba_GameOver : MonoBehaviour
{
    [SerializeField] Siba_PlayerHPController ShibaHP;
    [SerializeField] Siba_GameManager ShibaGM;
    [SerializeField] TextMeshProUGUI ShibaGameOver; //ゲームオーバーテキスト
    [SerializeField] Animator Shiba_PlayerAnim2;
    [SerializeField] GameObject ShibaRetryButtun; 


    void Start()
    {
        ShibaGameOver.gameObject.SetActive(false);
        ShibaRetryButtun.gameObject.SetActive(false);
        Shiba_PlayerAnim2.SetBool("isPlayerdead",false);
    }
    void Update()
    {
        if( ShibaHP.SibaPlayerHP1 <= 0 || ShibaGM.ShibaGameLimitTime1 <= 0)
        {
            if(ShibaHP.ShibaisAttackedQuit1)
            {
                StartCoroutine("DeadAnimation");
            }
        }
    }
    IEnumerator DeadAnimation()
    {
        Shiba_PlayerAnim2.SetBool("isPlayerdead",true);
        yield return new WaitForSeconds(2);
        ShibaGameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        ShibaRetryButtun.gameObject.SetActive(true);
        Time.timeScale = 0; //Unityの時間を停止
    }

    public void ButtunClick()
    {
        SceneManager.LoadScene("SibaGame");
        Time.timeScale = 1; //Unityの時間再開
    }
}
