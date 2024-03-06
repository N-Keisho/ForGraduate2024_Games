using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Siba_PlayerHPController : MonoBehaviour
{
    [SerializeField] public float SibaPlayerHP = 100;//プレイヤーのHP
    [SerializeField] TextMeshProUGUI SibaPlayerHPText; //プレイヤーHPの文字
    [SerializeField] Slider SibaPlayerHPGauge;// プレイヤーHPのスライダー
    void Start() 
    {
        SibaPlayerHPText.text = SibaPlayerHP.ToString("f0");
    }
    void Update()
    {
        SibaPlayerHPGauge.value = SibaPlayerHP;
        SibaPlayerHPText.text = SibaPlayerHP.ToString("f0");
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "sakura" || other.gameObject.tag == "Item")
        {
            SibaPlayerHP -= 20f;
            Destroy(other.gameObject);//当たったさくらのプレファブを消す
        }
    }
}
