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
        if (Input.GetKeyDown(KeyCode.B))
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
        Player1_Hiroppe bh
            = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
        bh.prepare_hiroppe += 1;

        if(bh.prepare_hiroppe == 2)
        {

            Player1_Hiroppe ph1
                = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
            ph1.gameStartHiroppe = true;
        }

        Destroy(GameObject.Find("HowtoPlay1"));
        Destroy(GameObject.Find("Image1"));
        Destroy(GameObject.Find("OKButtonHiroppe1"));
    }
}
