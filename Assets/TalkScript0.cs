using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkScript0 : MonoBehaviour
{
    [SerializeField] Text text;
    private string[] wordArray;
    private string words;
    // Start is called before the first frame update
    void Start()
    {
        words = "～,＄,ボ,タ,ン,を,タ,イ,ミ,ン,グ,よ,く,押,し,て,ね,。,ボ,タ,ン,を,押,せ,な,か,っ,た,り,、,早,く,押,し,す,ぎ,る,と,ダ,メ,ー,ジ,が,入,っ,ち,ゃ,う,よ,。,最,終,的,に,下,の,バ,ー,が,長,い,ほ,う,が,勝,ち,だ,よ,。\n,～,＄,さ,あ,、,ス,タ,ー,ト,ボ,タ,ン,を,押,し,て,ゲ,ー,ム,ス,タ,ー,ト,だ,よ,！";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            wordArray = words.Split(',');
            StartCoroutine("SetText");
        }
    }

    IEnumerator SetText()
    {
        foreach(var p in wordArray)
        {
            text.text = text.text + p;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
