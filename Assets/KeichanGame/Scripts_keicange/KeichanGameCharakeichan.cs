using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeichanGameCharakeichan : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite normal;
    public Sprite leftMove;
    public Sprite rightMove;

    public bool rideRhythm;
    int keisoku;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rideRhythm)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button2) | Input.GetKeyDown(KeyCode.A))
            {
                sprite.sprite = leftMove;
                keisoku = 0;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button1) | Input.GetKeyDown(KeyCode.D))
            {
                sprite.sprite = rightMove;
                keisoku = 0;
            }
            if (!Input.anyKeyDown)
            {
                keisoku++;
            }

            if (keisoku > 300)
            {
                sprite.sprite = normal;
            }
        }
    }
}
