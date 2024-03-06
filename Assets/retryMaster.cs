using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retryMaster : MonoBehaviour
{
    [SerializeField] string WattahGameMain;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TO KEISHO, SOTOUMI OR SOMEBODY: After merging, the name of the scene to be loaded must be changed.
        if (Input.GetKeyDown(KeyCode.Joystick1Button1)) SceneManager.LoadScene(WattahGameMain);
    }
}
