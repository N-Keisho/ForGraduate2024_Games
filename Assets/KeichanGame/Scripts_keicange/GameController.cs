using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int hp = 50;
    public float noteSpeed = 5;
    public GameObject[] notes;
    public bool startMusic;
    bool musicGo;

    public AudioClip battle;
    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {    
        startMusic = false;
        musicGo = true;
        BGM = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMusic && musicGo)
        {
            musicGo = false;
            StartCoroutine("Music");
            BGM.PlayOneShot(battle);
        }
    }

    IEnumerator Music()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            if (notes[i] != null)
            {
                Instantiate(notes[i]);
            }
            yield return new WaitForSeconds(0.05f);
            //Debug.Log(i);
        }
    }
}
