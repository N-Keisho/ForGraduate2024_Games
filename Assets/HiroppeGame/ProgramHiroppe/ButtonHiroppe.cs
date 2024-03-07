using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHiroppe : MonoBehaviour
{

    public AudioSource audioSourcehiroppe0;
    public AudioClip SE4hiroppe;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcehiroppe0 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.Joystick2Button3))
        {
            StartCoroutine("Cor");
        }
    }

    public void OnClick()
    {
        StartCoroutine("Cor");
    }

    IEnumerator Cor() //クリック音
    {
        audioSourcehiroppe0.PlayOneShot(SE4hiroppe);

        yield return new WaitWhile(() => audioSourcehiroppe0.isPlaying);
        Destroyhiroppe();

    }

    public void Destroyhiroppe()
    {
        Player1_Hiroppe bh
            = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
        bh.prepare_hiroppe += 1;

        if (bh.prepare_hiroppe == 2)
        {
            Player1_Hiroppe ph1
                = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
            ph1.gameStartHiroppe = true;
        }

        Destroy(GameObject.Find("HowtoPlay"));
        Destroy(GameObject.Find("Image"));
        Destroy(GameObject.Find("OKButtonHiroppe"));
    }
}
