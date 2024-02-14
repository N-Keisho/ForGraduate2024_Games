using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Siba_GameManager : MonoBehaviour
{
    [SerializeField] Slider ShibaBarrageGauge;
    [SerializeField] Animator ShibaAnim;
    [SerializeField] TextMeshProUGUI ShibaBarrageTimeText;
    [SerializeField] TextMeshProUGUI ShibaGameTimeText;
    [SerializeField] TextMeshProUGUI ShibaAreaJudgementText;
    [SerializeField] TextMeshProUGUI ShibaUsageGuideText;
    [SerializeField] float ShibaBarrageGaugeValue;
    public float ShibaBarrageGaugeValue1{ get{ return ShibaBarrageGaugeValue;}}
    [SerializeField] float ShibaBarrageLimitTime;
    [SerializeField] float ShibaGameLimitTime;
    [SerializeField] bool ShibaisGaugeArea;
    [SerializeField] bool ShibaisPlayerMove;
    public bool ShibaisPlayerMove1{ get{ return ShibaisPlayerMove;} }
    [SerializeField] bool ShibaisBarrageTimerQuit;
    public bool ShibaisBarrageTimerQuit1{ get{ return ShibaisBarrageTimerQuit;} }
    [SerializeField] bool ShibaisGameTimerQuit;
    [SerializeField] bool ShibaAlternateCheck;
    [SerializeField] bool ShibaAreaTextDisplay;

    [SerializeField] GameObject ShibaBarrageObject;
    [SerializeField] GameObject ShibaPlayer2;

    
    void Start()
    {
        ShibaBarrageGauge.gameObject.SetActive(false);
        ShibaAreaJudgementText.gameObject.SetActive(false);
        ShibaBarrageTimeText.gameObject.SetActive(false);
        ShibaisGaugeArea = false;
        ShibaisPlayerMove = true;
        ShibaisBarrageTimerQuit = true;
        ShibaisGameTimerQuit = true;
        ShibaAlternateCheck = true;
        ShibaAreaTextDisplay = true;
        ShibaBarrageGaugeValue = 0;
    }

    void Update()
    {
        if(ShibaisGameTimerQuit) StartCoroutine(GameLimitTimer());
        ShibaBarrageGauge.value = ShibaBarrageGaugeValue;
        ShibaisGaugeArea  = GaugeAreaJudgement();
        if (Input.GetKeyDown(KeyCode.Space) && ShibaisGaugeArea)
        {
            ShibaBarrageGauge.gameObject.SetActive(true);
            ShibaBarrageTimeText.gameObject.SetActive(true);
            ShibaGameTimeText.gameObject.SetActive(false);
            ShibaAnim.SetBool("Swing_bool",true);
            ShibaisPlayerMove = false;
            if (ShibaisBarrageTimerQuit) StartCoroutine(BarrageLimitTimer());
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            ShibaAnim.SetBool("Swing_bool",false);
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
        Vector3 TargetDirection = (ShibaPlayer2.transform.position - ShibaBarrageObject.transform.position).normalized;
        if (Physics.SphereCast(ShibaBarrageObject.transform.position, 0.0f, TargetDirection, out hit, 6.0f))
        {
            //Debug.Log(hit.transform.name);
            if (ShibaAreaTextDisplay)
            {
                ShibaAreaJudgementText.gameObject.SetActive(true);
            }
            else ShibaAreaJudgementText.gameObject.SetActive(false);
            return true;
        }
        else
        {
            ShibaAreaJudgementText.gameObject.SetActive(false);
            ShibaBarrageGauge.gameObject.SetActive(false);
            return false;
        }
    }
    // IEnumerator LimitTimer()は、連打の制限時間の管理
    IEnumerator BarrageLimitTimer()
    {
        ShibaBarrageLimitTime = 10;
        ShibaBarrageGaugeValue = 0;
        ShibaisBarrageTimerQuit = false;
        ShibaAreaTextDisplay = false;
        while (ShibaBarrageLimitTime > -1)
        {
            ShibaUsageGuideText.text = "れんだじかん";
            ShibaBarrageTimeText.text = ShibaBarrageLimitTime.ToString("f1") + "s";
            yield return new WaitForSeconds(1.0f);
            ShibaBarrageLimitTime -= 1.0f;
            ShibaGameLimitTime += 1.0f;
        }
        ShibaisBarrageTimerQuit = true;
        ShibaisPlayerMove = true; 
        ShibaAreaTextDisplay = true;
        ShibaBarrageGauge.gameObject.SetActive(false);
        ShibaBarrageTimeText.gameObject.SetActive(false); 
        ShibaGameTimeText.gameObject.SetActive(true);   
    }

    IEnumerator GameLimitTimer()
    {
        ShibaisGameTimerQuit = false;
        while (ShibaGameLimitTime > -1)
        {
            ShibaGameTimeText.text = ShibaGameLimitTime.ToString("f1") + "s";
            yield return new WaitForSeconds(1.0f);
            ShibaGameLimitTime -= 1.0f;
        }
        ShibaisGameTimerQuit = true;
    }

    // BarrageValueは、連打する機能を管理するシステム
    void BarrageValue()
    {
        bool isRightkeyPush = false;
        bool isLeftkeyPush = false;
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isLeftkeyPush && ShibaAlternateCheck)
        {
            isRightkeyPush = true;
            ShibaBarrageGaugeValue += 0.15f;
            ShibaAlternateCheck = false;
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRightkeyPush = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRightkeyPush && !ShibaAlternateCheck)
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
