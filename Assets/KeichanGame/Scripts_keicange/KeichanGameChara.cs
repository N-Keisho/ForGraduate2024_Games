using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeichanGameChara : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite normal;
    public Sprite leftMove;
    public Sprite rightMove;
    public KeyCode leftKey;
    public KeyCode rightKey;

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
            if (Input.GetKeyDown(leftKey))
            {
                //StartCoroutine(changeSprite(leftMove));
                sprite.sprite = leftMove;
                keisoku = 0;
            }
            if (Input.GetKeyDown(rightKey))
            {
                //StartCoroutine(changeSprite(rightMove));
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

    IEnumerator changeSprite(Sprite changeImgae)
    {
        sprite.sprite = changeImgae;
        yield return new WaitForSeconds(0.5f);
        sprite.sprite = normal;
    }
}
