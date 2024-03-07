using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHiroppe1 : MonoBehaviour
{
    public AudioSource audioSourcehiroppe1;
    public AudioClip SE5hiroppe;

    // Start is called before the first frame update
    void Start()
    {
        //ButtonHiroppe.prepare_hiroppe = 0;
        audioSourcehiroppe1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            StartCoroutine("Cor");
        }
    }

    IEnumerator Cor()
    {
        audioSourcehiroppe1.PlayOneShot(SE5hiroppe);

        yield return new WaitWhile(() => audioSourcehiroppe1.isPlaying);
        Destroyhiroppe();

    }

    public void OnClick()
    {
        StartCoroutine("Cor");
    }

    public void Destroyhiroppe()
    {
        Player2_Hiroppe bh
            = GameObject.Find("Player2_Hiroppe").GetComponent<Player2_Hiroppe>();
        bh.prepare_hiroppe1 += 1;

        if(bh.prepare_hiroppe1 == 2)
        { 

            Player2_Hiroppe ph2
                = GameObject.Find("Player2_Hiroppe").GetComponent<Player2_Hiroppe>();
            ph2.gameStartHiroppe1 = true;
        }

        Destroy(GameObject.Find("HowtoPlay1"));
        Destroy(GameObject.Find("Image1"));
        Destroy(GameObject.Find("OKButtonHiroppe1"));
    }
}
