using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchArrowControll : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite low;
    public Sprite high;
    public KeyCode key;
    void Start()
    {
        sprite= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            sprite.sprite = high;
            StartCoroutine("ColorBack");
        }
    }

    IEnumerator ColorBack()
    {
        yield return new WaitForSeconds(0.3f);
        sprite.sprite = low;
    }
}
