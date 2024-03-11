using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;
using System;

public class StoryScript : MonoBehaviour
{
    public GameObject[] serifs;
    bool ok;
    int i = 0;

    public TransitionSettings transition;
    public string nextScene;
    public KeyCode pushKey;
    void Start()
    {
        ok = false;
        StartCoroutine("serif");
    }

    private void LoadStage()
    {
        TransitionManager.Instance().Transition(nextScene, transition, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ok && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            i++;
            if (i == serifs.Length)
            {
                LoadStage();
            }

            serifs[i - 1].SetActive(false);
            serifs[i].SetActive(true);
            
        }

        if (Input.anyKey)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //èàóùÇèëÇ≠
                    Debug.Log(code);
                    break;
                }
            }
        }
    }

    

    IEnumerator serif()
    {
        yield return new WaitForSeconds(1);
        serifs[0].SetActive(true);
        ok = true;


        
    }
}
