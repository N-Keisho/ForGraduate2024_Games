using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Siba_GameManager : MonoBehaviour
{
    [SerializeField] Slider ShibaBarrageGauge;// 連打ゲージのスライダー
    [SerializeField] TextMeshProUGUI ShibaBarrageTimeText;// 連打の制限時間テキスト
    [SerializeField] TextMeshProUGUI ShibaGameTimeText;// ゲーム制限時間のテキスト
    [SerializeField] TextMeshProUGUI ShibaAreaJudgementText;// 連打エリアに入ると表示されるテキスト
    [SerializeField] float ShibaBarrageGaugeValue;// 連打ゲージの値を管理する
    public float ShibaBarrageGaugeValue1{ get{ return ShibaBarrageGaugeValue;}}
    [SerializeField] float ShibaGameLimitTime;// ゲーム制限時間をインスペクターで操作できるようにした
    [SerializeField] bool ShibaisPlayerMove;// Playerが動けることができるかのbool変数
    public bool ShibaisPlayerMove1{ get{ return ShibaisPlayerMove;} }
    [SerializeField] bool ShibaisBarrageTimerQuit;// 連打時間が終わったらtrueを返すbool変数
    public bool ShibaisBarrageTimerQuit1{ get{ return ShibaisBarrageTimerQuit;} }
    [SerializeField] GameObject ShibaBarrageObject;// 連打すると攻撃できるゲームオブジェクト
    [SerializeField] GameObject ShibaPlayer2;//Playerのゲームオブジェクト

    
    void Start()
    {
        ShibaBarrageGauge.gameObject.SetActive(false); //Slider_連打ゲージ
        ShibaAreaJudgementText.gameObject.SetActive(false); //Text_「何かのキー」
        ShibaBarrageTimeText.gameObject.SetActive(false); //Text_連打時間
        ShibaisPlayerMove = true; //Playerが動けるかのbool
        ShibaisBarrageTimerQuit = true; //連打時間が終わったのかのbool
        StartCoroutine(GameLimitTimer()); //ゲーム制限時間のコルーチン 
    }

    void Update()
    {
        bool ShibaisGaugeArea; //プレイヤーが連打エリアに入ってるかのbool
        ShibaBarrageGauge.value = ShibaBarrageGaugeValue; // ゲージの値がShibaBarrageGaugeValueによって変化する
        ShibaisGaugeArea  = GaugeAreaJudgement(); // GaugeAreaJudgement()関数で、連打エリアに入ってるかを確認
        if (Input.GetKeyDown(KeyCode.Space) 
            && 
            ShibaisGaugeArea
            &&
            ShibaisBarrageTimerQuit // 連打制限時間が終わっていたらtureのbool変数
            )
        {
            StartCoroutine(BarrageLimitTimer());// 連打制限時間の開始コルーチン
        }
        if (!ShibaisBarrageTimerQuit)
        {
            BarrageValue();// 連打時間実行中だと、連打によってゲージが変わるようにする関数
        }
    }
    //GaugeAreaJudgement()は、連打できる範囲を判定してくれる関数
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
    // IEnumerator LimitTimer()は、連打の制限時間を1秒ごとに減らしてくれるコルーチン
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
            ShibaBarrageTimeText.text = "れんだじかん  " + ShibaBarrageLimitTime.ToString("f1") + "s";
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
    // GameLimitTimer()は、ゲーム制限時間を１秒ごとに減らすコルーチン
    IEnumerator GameLimitTimer()
    {
        while (ShibaGameLimitTime > -1)
        {
            ShibaGameTimeText.text = "のこりじかん" + ShibaGameLimitTime.ToString("f1") + "s";
            yield return new WaitForSeconds(1.0f);
            ShibaGameLimitTime -= 1.0f;
        }
    }

    // BarrageValue()は、矢印キーを交互に押すと、連打ゲージがたまっていく関数
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
