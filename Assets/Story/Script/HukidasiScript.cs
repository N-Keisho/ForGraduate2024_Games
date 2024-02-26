using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HukidasiScript : MonoBehaviour
{
    Transform mainCameraTransform;
    public string nextScene;
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
