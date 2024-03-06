using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiba_CameraMove : MonoBehaviour
{
    [SerializeField] GameObject ShibaPlayer3;
    void Update()
    {
        float posx = ShibaPlayer3.transform.position.x;
        float posy = ShibaPlayer3.transform.position.y;
        float posz = ShibaPlayer3.transform.position.z;
        transform.position = new Vector3(posx, posy + 2.5f, posz - 4.5f);
    }
}
