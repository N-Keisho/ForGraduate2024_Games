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
        words = "�E,�{,�^,��,��,�^,�C,�~,��,�O,��,��,��,��,��,��,�B,�{,�^,��,��,��,��,��,��,��,��,��,�A,��,��,��,��,��,��,��,��,�_,��,�[,�W,��,��,��,��,��,��,��,�B,��,�I,�I,��,��,��,�o,�[,��,��,��,��,��,��,��,��,��,��,�B\n,�E,��,��,�A,�X,�^,�[,�g,�{,�^,��,��,��,��,��,�Q,�[,��,�X,�^,�[,�g,��,��,�I";
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
