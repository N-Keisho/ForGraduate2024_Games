using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchArrowControllER : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Joystick2Button1) | Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log(key);
            sprite.sprite = high;
            transform.localScale = new Vector3(-0.9f, 0.9f, 0.9f);
            StartCoroutine("ColorBack");
        }
    }

    IEnumerator ColorBack()
    {
        yield return new WaitForSeconds(0.2f);
        transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        sprite.sprite = low;
    }
}
