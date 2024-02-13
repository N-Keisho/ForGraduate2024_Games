using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Siba_GameManager : MonoBehaviour
{
    [SerializeField] Slider ShibaGauge;
    [SerializeField] float ShibaGaugeValue;
    [SerializeField] bool ShibaisGaugeArea;

    [SerializeField] GameObject ShibaBarrageObject;
    [SerializeField] GameObject ShibaPlayer2;

    [SerializeField] Animator ShibaAnim;

    void Start()
    {
        ShibaGauge.gameObject.SetActive(false);
        ShibaisGaugeArea = false;
        ShibaGaugeValue = 0;
    }

    void Update()
    {
        ShibaGauge.value = ShibaGaugeValue;
        ShibaisGaugeArea  = GaugeAreaJudgement();
        //Debug.Log("ShibaisGaugeArea: " + ShibaisGaugeArea);
        if (Input.GetKeyDown(KeyCode.Space) && ShibaisGaugeArea)
        {
            ShibaGauge.gameObject.SetActive(true);
            ShibaAnim.SetBool("Swing_bool",true);
        }

        else if(Input.GetKeyUp(KeyCode.Space))
        {
            ShibaAnim.SetBool("Swing_bool",false);
        }
    }

    bool GaugeAreaJudgement()
    {
        RaycastHit hit;
        Vector3 TargetDirection = (ShibaPlayer2.transform.position - ShibaBarrageObject.transform.position).normalized;
        if (Physics.SphereCast(ShibaBarrageObject.transform.position, 0.0f, TargetDirection, out hit, 6.0f))
        {
            Debug.Log(hit.transform.name);
            return true;
        }
        else
        {
            ShibaGauge.gameObject.SetActive(false);
            return false;
        }
    }
}
