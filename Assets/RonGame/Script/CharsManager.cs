using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// UIの表裏を実装する
/// 裏返し・表返しのアニメーションを実装する
/// </summary>

public class CharsManager : MonoBehaviour
{
    RectTransform rectTransform; //RectTransformコンポーネント
    public int sequence = 0; //表裏の状態を管理する変数. 0:未回答, 1:解答済み, 2:正解
    public string answer = ""; //正解の文字列
    public bool isCorrect = false; //正解したかどうか

    Image image; //Imageコンポーネント
    Sprite defaltSprite; //表面のスプライト（画像）
    [SerializeField] Sprite readySprite; // 解答入力後のスプライト
    [SerializeField] Sprite answerSprite; // 解答表示のスプライト
    [SerializeField] TMP_Text text; // 解答表示のテキスト

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); //recttransformコンポーネント取得
        image = GetComponent<Image>(); //Imageコンポーネント取得
        defaltSprite = image.sprite; //表面のスプライト（画像）を変数に保存
    }

    void Update()
    {
        //ここでメソッドを毎フレーム呼ぶ
        ChangeAnim();
    }

    //以下は毎フレーム呼ぶことで連続したアニメーションになるメソッド
    void ChangeAnim()
    {
        //表返し
        if(sequence == 1) // 回答したらreadyにする
        {
            if(rectTransform.eulerAngles.y < 180) //もしrotation.yが180未満だったら
            {
                rectTransform.Rotate(0, 1, 0); //回転する

                //rotation.yが90以上で、かつ表示されているスプライトが裏のスプライトではなかったら
                if(rectTransform.eulerAngles.y >90)
                {
                    image.sprite = readySprite; //回答済みのスプライトにする
                }
            }
        }
        else if(sequence == 2) // 正解したらanswerにする
        {
            if (rectTransform.eulerAngles.y > 0) //もしrotation.yが180未満だったら
            {
                rectTransform.Rotate(0, 1, 0); //回転する

                //rotation.yが90以上で、かつ表示されているスプライトが裏のスプライトではなかったら
                if (rectTransform.eulerAngles.y > 270)
                {
                    text.text = answer; //正解の文字列を表示
                    image.sprite = answerSprite; //裏のスプライトにする
                    if(isCorrect) image.color = new Color(0, 1, 0, 1); //正解したら緑色にする
                    else image.color = new Color(1, 0, 0, 1); //不正解だったら赤色にする
                }
            }
        }
    }
}
