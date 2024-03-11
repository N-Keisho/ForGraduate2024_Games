using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rirWalkAnim : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    PlayerScript playerScript;
    void Start()
    {
        playerScript = GameObject.Find("Riry").GetComponent<PlayerScript>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.moveOK)
        {
            if (Input.GetKey(KeyCode.JoystickButton0) | Input.GetKey(KeyCode.JoystickButton1) | Input.GetKey(KeyCode.JoystickButton2) | Input.GetKey(KeyCode.JoystickButton3))
            {

                //anim.SetBool("Walking", true);
            }
        }

        if (!Input.anyKey)
        {
            anim.SetBool("Walking", false);
        }

    }
}
