using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//enumを使うために必要
using System;
public class Shiba_DownKeyChecker : MonoBehaviour
{
    void Update () 
    {
        DownKeyCheck ();
    }


    void DownKeyCheck()
    {
        if (Input.anyKeyDown) 
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode))) 
            {
                if (Input.GetKeyDown (code)) 
                {
                  //処理を書く
                    Debug.Log (code);
                    break;
                }
            }
        }
    }

} 
   