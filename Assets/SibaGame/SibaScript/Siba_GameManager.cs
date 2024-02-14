using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Siba_GameManager : MonoBehaviour
{
    [SerializeField] Slider ShibaGauge;
    [SerializeField] Animator ShibaAnim;
    [SerializeField] TextMeshProUGUI ShibaTimeText;
    [SerializeField] TextMeshProUGUI ShibaAreaJudgement;

    [SerializeField] float ShibaGaugeValue;
    [SerializeField] float ShibaLimitTime;
    [SerializeField] bool ShibaisGaugeArea;
    [SerializeField] bool ShibaisPlayerMove;
    public bool ShibaisPlayerMove1{ get{ return ShibaisPlayerMove;} }
    [SerializeField] bool ShibaisLimitTimer;
    [SerializeField] bool ShibaAlternateCheck;
    [SerializeField] bool ShibaAreaTextDisplay;

    [SerializeField] GameObject ShibaBarrageObject;
    [SerializeField] GameObject ShibaPlayer2;

    
    void Start()
    {
        ShibaGauge.gameObject.SetActive(false);
        ShibaAreaJudgement.gameObject.SetActive(false);
        ShibaisGaugeArea = false;
        ShibaGaugeValue = 0;
        ShibaisPlayerMove = true;
        ShibaisLimitTimer = false;
        ShibaAlternateCheck = true;
        ShibaAreaTextDisplay = true;
    }

    void Update()
    {
        ShibaGauge.value = ShibaGaugeValue;
        ShibaisGaugeArea  = GaugeAreaJudgement();
        if (Input.GetKeyDown(KeyCode.Space) && ShibaisGaugeArea)
        {
            ShibaGauge.gameObject.SetActive(true);
            ShibaAnim.SetBool("Swing_bool",true);
            ShibaisPlayerMove = false;
            if (!ShibaisLimitTimer) StartCoroutine(LimitTimer());
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            ShibaAnim.SetBool("Swing_bool",false);
        }
        if (ShibaisLimitTimer)
        {
            BarrageValue();
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
                ShibaAreaJudgement.gameObject.SetActive(true);
            }
            else ShibaAreaJudgement.gameObject.SetActive(false);
            return true;
        }
        else
        {
            ShibaAreaJudgement.gameObject.SetActive(false);
            ShibaGauge.gameObject.SetActive(false);
            return false;
        }
    }
    IEnumerator LimitTimer()
    {
        ShibaLimitTime = 10;
        ShibaisLimitTimer = true;
        ShibaAreaTextDisplay = false;

        while (ShibaLimitTime > -1)
        {
            ShibaTimeText.text = ShibaLimitTime.ToString("f1") + "s";
            yield return new WaitForSeconds(1.0f);
            ShibaLimitTime -= 1.0f;
        }
        ShibaisPlayerMove = true;
        ShibaisLimitTimer = false; 
        ShibaAreaTextDisplay = true;    
    }

    void BarrageValue()
    {
        bool isRightkeyPush = false;
        bool isLeftkeyPush = false;
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isLeftkeyPush && ShibaAlternateCheck)
        {
            isRightkeyPush = true;
            ShibaGaugeValue += 1.0f;
            ShibaAlternateCheck = false;
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRightkeyPush = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRightkeyPush && !ShibaAlternateCheck)
        {
            isLeftkeyPush = true;
            ShibaGaugeValue += 1.0f;
            ShibaAlternateCheck = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isLeftkeyPush = false;
        }
    }
}
