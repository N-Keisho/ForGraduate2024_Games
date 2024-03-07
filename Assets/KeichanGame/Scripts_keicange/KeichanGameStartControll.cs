using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeichanGameStartControll : MonoBehaviour
{
    AudioSource audio;
    public AudioClip keichanVoice;
    SpriteRenderer sprite;
    public Sprite ready;
    public Sprite go;
    public bool spriteOn;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audio= GetComponent<AudioSource>();
        sprite.sprite = ready;
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteOn)
        {
            spriteOn = false;
            StartCoroutine("startGame");
            audio.PlayOneShot(keichanVoice);
        }
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1.2f);
        sprite.sprite = go;
        yield return new WaitForSeconds(0.5f);
    }
}
