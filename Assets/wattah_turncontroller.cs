using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wattahgame_turncontroller : MonoBehaviour
{
    

    private int wattahTurn;
    public TextMeshProUGUI wattahgame_turnText;

    public wattahgame_ArrowInputRecorder wattahgame_ArrowInputRecorder;

    // Start is called before the first frame update
    void Start()
    {
        wattahTurn = 1;
    }

    // Update is called once per frame
    void Update()
    {
         
        wattahTurn = wattahgame_ArrowInputRecorder.wattahgamecurrentPlayer;
        if(wattahTurn == 1)
        {
            wattahgame_turnText.text = "わったーの番";
        }

        if(wattahTurn == 2)
        {
            wattahgame_turnText.text = "りりーの番";
        }
    }
}
