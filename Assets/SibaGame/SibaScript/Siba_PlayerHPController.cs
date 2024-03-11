using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Siba_PlayerHPController : MonoBehaviour
{
    [SerializeField] public float SibaPlayerHP = 100;//プレイヤーのHP
    public float SibaPlayerHP1{ get{ return SibaPlayerHP;}}
    [SerializeField] TextMeshProUGUI SibaPlayerHPText; //プレイヤーHPの文字
    [SerializeField] Slider SibaPlayerHPGauge;// プレイヤーHPのスライダー
    [SerializeField] Animator Siba_PlayerAnim1;// プレイヤーのアニメーション
    [SerializeField] private bool ShibaisAttackedQuit;// プレイヤーが攻撃を食らうアニメーションが終わってるかどうか
    public bool ShibaisAttackedQuit1{ get{ return ShibaisAttackedQuit;}}
    void Start() 
    {
        SibaPlayerHPText.text = SibaPlayerHP.ToString("f0");
        ShibaisAttackedQuit = true;
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
            ShibaisAttackedQuit = false;
            Siba_PlayerAnim1.SetBool("isAttacked1", true);
            SibaPlayerHP -= 20f;
            Destroy(other.gameObject);//当たったさくらのプレファブを消す
            StartCoroutine("isAttackedStop1");
        }
    }
    IEnumerator isAttackedStop1(){
        yield return new WaitForSeconds(3);
        Siba_PlayerAnim1.SetBool("isAttacked1", false);
        yield return new WaitForSeconds(0.5f);
        ShibaisAttackedQuit = true;
    }
}
