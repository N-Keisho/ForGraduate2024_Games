using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int hp = 50;
    public float noteSpeed = 5;
    public GameObject[] notes;
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Music()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            if (notes[i] == null)
            {
                notes[i] = pause;
            }
            Debug.Log(i);
            Instantiate(notes[i]);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
