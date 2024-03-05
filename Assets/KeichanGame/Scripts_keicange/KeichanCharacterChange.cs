using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeichanCharacterChange : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite normal;
    public Sprite leftMove;
    public Sprite rightMove;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public bool rideRhythm;
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
                StartCoroutine(changeSprite(leftMove));
            }
            if (Input.GetKeyDown(rightKey))
            {
                StartCoroutine(changeSprite(rightMove));
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
