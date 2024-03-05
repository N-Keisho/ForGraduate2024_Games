using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStop : MonoBehaviour
{
    // Start is called before the first frame update
    public bool animationEnd = false;
    public void StopAnimation()
    {
        Animator airPlane = GetComponent<Animator>();
        airPlane.enabled = false;
        animationEnd = true;
    }
}
