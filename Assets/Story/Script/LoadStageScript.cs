using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;

public class LoadStageScript : MonoBehaviour
{
    public TransitionSettings transition;
    public string stageName;

    // Start is called before the first frame update
    private void LoadStage()
    {
        TransitionManager.Instance().Transition(stageName, transition, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            LoadStage();
        }
    }
}
