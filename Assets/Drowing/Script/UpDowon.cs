using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float speed = 0.7f; //　移動スピード
    public float moveY = 0.2f; // 移動値
    private Vector3 pos;

    private AnimationStop animationStop;
    private bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<RectTransform>().position;
        try{
            animationStop = GetComponent<AnimationStop>();
        }catch{
            animationStop = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animationStop)
        {
            if (animationStop.animationEnd)
            {
                if (!once)
                {
                    pos = GetComponent<RectTransform>().position;
                    once = true;
                }
                Move();
            }
        }
        else if (animationStop == null)
        {
            Move();
            
        }
    }

    void Move(){
        Vector3 p = GetComponent<RectTransform>().position;
        GetComponent<RectTransform>().position = new Vector3(p.x, pos.y + Mathf.Sin(Time.time * speed) * moveY, p.z);
    }
}
