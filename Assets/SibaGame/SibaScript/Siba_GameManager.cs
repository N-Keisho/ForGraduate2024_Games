using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Siba_GameManager : MonoBehaviour
{
    [SerializeField] Slider ShibaBarrageGauge;
    [SerializeField] TextMeshProUGUI ShibaBarrageTimeText;
    [SerializeField] TextMeshProUGUI ShibaGameTimeText;
    [SerializeField] TextMeshProUGUI ShibaAreaJudgementText;
    [SerializeField] TextMeshProUGUI ShibaUsageGuideText;
    [SerializeField] float ShibaBarrageGaugeValue;
    public float ShibaBarrageGaugeValue1{ get{ return ShibaBarrageGaugeValue;}}
    [SerializeField] float ShibaGameLimitTime;
    [SerializeField] bool ShibaisPlayerMove;
    public bool ShibaisPlayerMove1{ get{ return ShibaisPlayerMove;} }
    [SerializeField] bool ShibaisBarrageTimerQuit;
    public bool ShibaisBarrageTimerQuit1{ get{ return ShibaisBarrageTimerQuit;} }
    [SerializeField] bool ShibaAreaTextDisplay;

    [SerializeField] GameObject ShibaBarrageObject;
    [SerializeField] GameObject ShibaPlayer2;

    
    void Start()
    {
        ShibaBarrageGauge.gameObject.SetActive(false); //Slider_連打ゲージ
        ShibaAreaJudgementText.gameObject.SetActive(false); //Text_「何かのキー」
        ShibaBarrageTimeText.gameObject.SetActive(false); //Text_連打時間
        ShibaisPlayerMove = true;
        ShibaisBarrageTimerQuit = true;
        StartCoroutine(GameLimitTimer());
    }

    void Update()
    {
        bool ShibaisGaugeArea;
        ShibaBarrageGauge.value = ShibaBarrageGaugeValue;
        ShibaisGaugeArea  = GaugeAreaJudgement();
        if (Input.GetKeyDown(KeyCode.Space) 
            && 
            ShibaisGaugeArea
            &&
            ShibaisBarrageTimerQuit
            )
        {
            StartCoroutine(BarrageLimitTimer());
        }
        if (!ShibaisBarrageTimerQuit)
        {
            BarrageValue();
        }
        else
        {
            ShibaUsageGuideText.text = "のこりじかん";
        }
    }
    //GaugeAreaJudgementは、連打できる範囲を管理する
    bool GaugeAreaJudgement()
    {
        RaycastHit hit;
        Vector3 StartPosition = ShibaBarrageObject.transform.position;
        Vector3 DestinationPosition = ShibaPlayer2.transform.position;
        Vector3 TargetDirection = (DestinationPosition - StartPosition).normalized;
        if (DestinationPosition.z < 18 
            && 
            Physics.SphereCast(StartPosition, 0.0f , TargetDirection, out hit, 6.0f)
            &&
            ShibaisBarrageTimerQuit
            )
        {
            ShibaAreaJudgementText.gameObject.SetActive(true);
            return true;
        }
        else 
        {
            ShibaAreaJudgementText.gameObject.SetActive(false);
            return false;
        }
    }
    // OnDrawGizmos()シーンビューで連打エリアを表示化
    void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ShibaBarrageObject.transform.position, 6.0f);
    }
    // IEnumerator LimitTimer()は、連打の制限時間の管理
    IEnumerator BarrageLimitTimer()
    {
        float ShibaBarrageLimitTime = 10;
        ShibaBarrageGaugeValue = 0;
        ShibaBarrageGauge.gameObject.SetActive(true);
        ShibaBarrageTimeText.gameObject.SetActive(true);
        ShibaGameTimeText.gameObject.SetActive(false);
        ShibaisBarrageTimerQuit = false;
        ShibaisPlayerMove = false;
        while (ShibaBarrageLimitTime > -1)
        {
            ShibaUsageGuideText.text = "れんだじかん";
            ShibaBarrageTimeText.text = ShibaBarrageLimitTime.ToString("f1") + "s";
            yield return new WaitForSeconds(1.0f);
            ShibaBarrageLimitTime -= 1.0f;
            ShibaGameLimitTime += 1.0f;
        }
        ShibaBarrageGauge.gameObject.SetActive(false);
        ShibaBarrageTimeText.gameObject.SetActive(false); 
        ShibaGameTimeText.gameObject.SetActive(true);    
        ShibaisBarrageTimerQuit = true;
        ShibaisPlayerMove = true;
    }

    IEnumerator GameLimitTimer()
    {
        while (ShibaGameLimitTime > -1)
        {
            ShibaGameTimeText.text = ShibaGameLimitTime.ToString("f1") + "s";
            yield return new WaitForSeconds(1.0f);
            ShibaGameLimitTime -= 1.0f;
        }
    }

    // BarrageValueは、連打する機能を管理するシステム
    void BarrageValue()
    {
        bool isRightkeyPush = false;
        bool isLeftkeyPush = false;
        bool ShibaAlternateCheck = true;
        if (Input.GetKeyDown(KeyCode.RightArrow) 
            && 
            !isLeftkeyPush 
            && 
            ShibaAlternateCheck)
        {
            isRightkeyPush = true;
            ShibaBarrageGaugeValue += 0.15f;
            ShibaAlternateCheck = false;
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRightkeyPush = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) 
            && 
            !isRightkeyPush 
            && 
            !ShibaAlternateCheck)
        {
            isLeftkeyPush = true;
            ShibaBarrageGaugeValue += 0.15f;
            ShibaAlternateCheck = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isLeftkeyPush = false;
        }
    }
}
