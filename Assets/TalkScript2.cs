using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkScript2 : MonoBehaviour
{
    [SerializeField] Text text;
    private string[] wordArray;
    private string words;
    // Start is called before the first frame update
    void Start()
    {
        words = "～,＄,p,i,n,k,の,矢,印,は,押,し,て,O,K,、,\n,だ,け,ど,N,o,A,r,r,o,w,は,押,し,た,ら,ダ,メ,ー,ジ,を,受,け,ち,ゃ,う,よ,。,\n,～,＄,気,を,付,け,て,ね,。";
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
