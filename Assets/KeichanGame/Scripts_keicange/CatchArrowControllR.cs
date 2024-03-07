using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchArrowControllR : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite low;
    public Sprite high;
    void Start()
    {
        sprite= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            //Debug.Log(key);
            sprite.sprite = high;
            StartCoroutine("ColorBack");
        }
    }

    IEnumerator ColorBack()
    {
        yield return new WaitForSeconds(0.2f);
        sprite.sprite = low;
    }
}
