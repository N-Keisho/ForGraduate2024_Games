using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeichanGameStartControll : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite ready;
    public Sprite go;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = ready;
        StartCoroutine("startGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1);
        sprite.sprite = go;
        yield return new WaitForSeconds(0.5f);
    }
}
