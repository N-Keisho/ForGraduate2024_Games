using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;

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
        if (ok && Input.GetKeyDown(pushKey))
        {
            i++;
            if (i == 15)
            {
                LoadStage();
            }

            serifs[i - 1].SetActive(false);
            serifs[i].SetActive(true);
            
        }
    }

    

    IEnumerator serif()
    {
        yield return new WaitForSeconds(1);
        serifs[0].SetActive(true);
        ok = true;


        
    }
}
