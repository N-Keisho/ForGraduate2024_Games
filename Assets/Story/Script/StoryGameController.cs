using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGameController : MonoBehaviour
{
    public bool hiroppeClear;
    public bool sibaClear;
    public bool keichanClear;
    public bool tukkunClear;
    public bool wattaClear;

    public GameObject nextStageWall1;
    public GameObject nextStageWall2;
    public GameObject nextStageWall3;
    public GameObject nextStageWall4;
    public GameObject nextStageWall5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hiroppeClear)
        {
            nextStageWall1.SetActive(false);
        }
    }
}
