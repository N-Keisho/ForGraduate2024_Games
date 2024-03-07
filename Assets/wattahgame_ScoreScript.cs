using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wattahgame_ScoreScript : MonoBehaviour
{
    

    private int wattahScore;
    public TextMeshProUGUI wattahgame_ScoreText;

    public wattahgame_ArrowInputRecorder wattahgame_ArrowInputRecorder;

    // Start is called before the first frame update
    void Start()
    {
        wattahScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
         
        wattahScore = wattahgame_ArrowInputRecorder.mismatches;
        wattahgame_ScoreText.text = "ミス数：" + wattahScore.ToString();
    }
}
