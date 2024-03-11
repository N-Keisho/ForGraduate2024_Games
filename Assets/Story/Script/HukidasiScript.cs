using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;

public class HukidasiScript : MonoBehaviour
{
    Transform mainCameraTransform;
    public TransitionSettings transition;
    public string nextScene;
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void LoadStage()
    {
        TransitionManager.Instance().Transition(nextScene, transition, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = mainCameraTransform.position - transform.position;
        lookDir.y = 0f;

        if (lookDir != Vector3.zero)
        {
            transform.forward = lookDir.normalized;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton11) | Input.GetKeyDown(KeyCode.Space))
        {
            LoadStage();
        }
    }
}
