using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Question1 : MonoBehaviour
{
    [SerializeField] Image[] chars = new Image[6];
    [SerializeField] Image[] minhaya = new Image[5];
    [SerializeField] GameObject Minhaya;
    [SerializeField] TMP_Text[] minhayaTexts = new TMP_Text[5];
    [SerializeField] GameObject answerText;
    private CharsManager[] charsManager = new CharsManager[6];
    private int[] sequences = new int[6] { 0, 0, 0, 0, 0, 0 }; //表裏の状態を管理する変数. 0:未回答, 1:解答済み, 2:正解
    private string[] answers = new string[6] { "", "", "", "", "", "" }; //回答の文字列
    private string[] correctAnswers = new string[6] { "や", "ま", "な", "し", "り", "こ" }; //正解の文字列
                                                                                     
    private string[][] minhayaStringsOrigin = new string[6][] //問題の文字列
    {
        new string[5]{"や", "な", "さ", "す", "し"},
        new string[5]{"ま", "が", "と", "ず", "ば"},
        new string[5]{"な", "い", "う", "き", "た"},
        new string[5]{"し", "は", "の", "ゆ", "ね"},
        new string[5]{"り", "や", "ぞ", "な", "む"},
        new string[5]{"こ", "と", "む", "き", "か"},
    };

    private string[][] minhayaStrings = new string[6][] //問題の文字列
    {
        new string[5], new string[5], new string[5], new string[5], new string[5], new string[5]
    };

    public int number = 0; //選択中の文字の番号
    public int selected = 0; //選択中の文字の番号
    private bool isFin = false;
    private bool isResult = false;


    void Start()
    {
        Minhaya.SetActive(true);
        answerText.SetActive(false);

        for (int i = 0; i < chars.Length; i++)
        {
            charsManager[i] = chars[i].GetComponent<CharsManager>();
        }


        // 文字列をシャッフルする
        for (int i = 0; i < minhayaStrings.Length; i++)
        {
            List<int> indexes = new List<int>();
            for (int j = 0; j < minhayaStringsOrigin[i].Length; j++)
            {
                while (true)
                {
                    int index = Random.Range(0, minhayaStringsOrigin[i].Length);
                    if (!indexes.Contains(index))
                    {
                        indexes.Add(index);
                        minhayaStrings[i][j] = minhayaStringsOrigin[i][index];
                        break;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFin)
        {
            if (Input.anyKeyDown)
            {
                Animator anim = GetComponent<Animator>();
                anim.SetBool("fin", true);
                RonGameManager rgm = GameObject.Find("_GameManager_").GetComponent<RonGameManager>();
                rgm.questionEnd[1] = true;
            }

        }
        else if(!isResult)
        {
            // 文字列を常に更新する
            for (int i = 0; i < minhaya.Length; i++)
            {
                minhayaTexts[i].text = minhayaStrings[number][i];
                if (selected == i)
                {
                    minhaya[i].color = new Color(1, 1, 0, 1);
                }
                else
                {
                    minhaya[i].color = new Color(1, 1, 1, 1);
                }
            }

            // 操作を受け付ける
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                selected = (selected + 4) % 5;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                selected = (selected + 1) % 5;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton10) || Input.GetKeyDown(KeyCode.JoystickButton11))
            {
                answers[number] = minhayaStrings[number][selected];
                charsManager[number].sequence = 1;
                charsManager[number].answer = answers[number];
                selected = 0;
                if (answers[number] == correctAnswers[number])
                {
                    charsManager[number].isCorrect = true;
                }

                if (number < chars.Length - 1)
                {
                    number++;
                }
                else
                {
                    isResult = true;
                    StartCoroutine(Fin());
                }
            }
        }

    }

    IEnumerator Fin()
    {
        // みんはやを非表示にする
        Minhaya.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        // 一つずつ回答を表示する
        for (int i = 0; i < chars.Length; i++)
        {
            charsManager[i].sequence = 2;
            yield return new WaitForSeconds(0.2f);
        }

        // 答えを表示する
        answerText.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        // 正解だったかどうかを格納する
        bool allCorrect = true;
        for (int i = 0; i < charsManager.Length; i++)
        {
            if (!charsManager[i].isCorrect)
                allCorrect = false;
        }
        QuestionManager questionManager = GameObject.Find("_QuestionManager_").GetComponent<QuestionManager>();
        questionManager.correct[questionManager.currentQuestion] = allCorrect;


        isFin = true;
    }
}
