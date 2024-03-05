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
    [SerializeField] GameObject ShibaPlayer2;// Playerのゲームオブジェクト
    [SerializeField] bool ShibaisAttackTrigger;// 連打後のアタック可能かのbool変数
    public bool ShibaisAttackTrigger1{ get{ return ShibaisAttackTrigger;} set{ ShibaisAttackTrigger = value;} }
    [SerializeField] bool Shiba_PlayerAlternateCheck;//プレイヤー連打の右、左の切り替え判定
    [SerializeField] bool Shiba_ShibaAlternateCheck;//しば連打のD、Aの切り替え判定
    
    void Start()
    {
        ShibaBarrageGauge.gameObject.SetActive(false); //Slider_連打ゲージ
        ShibaAreaJudgementText.gameObject.SetActive(false); //Text_「何かのキー」
        ShibaBarrageTimeText.gameObject.SetActive(false); //Text_連打時間
        ShibaisPlayerMove = true; //Playerが動けるかのbool
        ShibaisBarrageTimerQuit = true; //連打時間が終わったのかのbool
        ShibaisAttackTrigger = false; //連打後のアタック可能かのbool
        StartCoroutine(GameLimitTimer()); //ゲーム制限時間のコルーチン

        Shiba_PlayerAlternateCheck = true; //プレイヤー連打ボタン切り替えのbool
        Shiba_ShibaAlternateCheck = true; //しば連打ボタン切り替えのbool
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
        ShibaBarrageGaugeValue = 60;
        ShibaBarrageGauge.gameObject.SetActive(true); //Slider_連打ゲージ
        ShibaBarrageTimeText.gameObject.SetActive(true); //Text_連打時間
        ShibaGameTimeText.gameObject.SetActive(false); //Text_ゲーム制限時間
        ShibaisBarrageTimerQuit = false; 
        ShibaisPlayerMove = false;
        while (ShibaBarrageLimitTime > -1)
        {
            ShibaBarrageTimeText.text = "れんだじかん  " + ShibaBarrageLimitTime.ToString("f1") + "s";
            yield return new WaitForSeconds(1.0f);
            ShibaBarrageLimitTime -= 1.0f;
            ShibaGameLimitTime += 1.0f;
        }
        ShibaBarrageGauge.gameObject.SetActive(false); //Slider_連打ゲージ
        ShibaBarrageTimeText.gameObject.SetActive(false); //Text_連打時間
        ShibaGameTimeText.gameObject.SetActive(true);  //Text_ゲーム制限時間
        ShibaisAttackTrigger = true;  
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
        // プレイヤーの連打に関する変数
        bool isRightkeyPush = false;
        bool isLeftkeyPush = false;
        
        //　しばの連打に関する変数
        bool isDkeyPush = false;
        bool isAkeyPush = false;

        // プレイヤーが右キーを押したらゲージがたまる条件
        if (Input.GetKeyDown(KeyCode.RightArrow) 
            && 
            !isLeftkeyPush 
            && 
            Shiba_PlayerAlternateCheck)
        {
            isRightkeyPush = true;
            ShibaBarrageGaugeValue += 6.0f;
            Shiba_PlayerAlternateCheck = false;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRightkeyPush = false;
        }

        // プレイヤーが左キーを押したら、ゲージがたまる条件
        if (Input.GetKeyDown(KeyCode.LeftArrow) 
            && 
            !isRightkeyPush 
            && 
            !Shiba_PlayerAlternateCheck)
        {
            isLeftkeyPush = true;
            ShibaBarrageGaugeValue += 6.0f;
            Shiba_PlayerAlternateCheck = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isLeftkeyPush = false;
        }
        
        // しばがDキーを押したらゲージを減らす条件
        if (Input.GetKeyDown(KeyCode.D) 
            && 
            !isAkeyPush 
            && 
            Shiba_ShibaAlternateCheck)
        {
            isDkeyPush = true;
            ShibaBarrageGaugeValue -= 6.0f;
            Shiba_ShibaAlternateCheck = false;
        }

        // しばがAキーを押したら、ゲージを減らす条件
        if (Input.GetKeyDown(KeyCode.A) 
            && 
            !isDkeyPush 
            && 
            !Shiba_ShibaAlternateCheck)
        {
            isAkeyPush = true;
            ShibaBarrageGaugeValue -= 6.0f;
            Shiba_ShibaAlternateCheck = true;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            isAkeyPush = false;
        }
    }
}
