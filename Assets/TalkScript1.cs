using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkScript1 : MonoBehaviour
{
    [SerializeField] Text text;
    private string[] wordArray;
    private string words;
    // Start is called before the first frame update
    void Start()
    {
        words = "～,＄,左,側,は,け,い,ち,ゃ,ん,が,操,作,し,、,左,矢,印,は,A,キ,ー,で,操,作,を,行,い,、,右,矢,印,は,D,キ,ー,で,操,作,す,る,よ,。,\n,～,＄,プ,レ,イ,ヤ,ー,は,右,画,面,を,操,作,し,て,、,左,矢,印,は,左,矢,印,キ,ー,で,操,作,し,、,右,矢,印,は,右,矢,印,キ,ー,で,操,作,す,る,よ";
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
        foreach (var p in wordArray)
        {
            text.text = text.text + p;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
