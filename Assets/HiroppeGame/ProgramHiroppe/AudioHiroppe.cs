using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHiroppe : MonoBehaviour
{
    public AudioSource audioSourcehiroppe;
    public AudioClip SE1hiroppe;
    public AudioClip SE2hiroppe;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcehiroppe = GetComponent<AudioSource>();
        StartCoroutine("Soundhiroppe");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Soundhiroppe()
    {
        audioSourcehiroppe.PlayOneShot(SE1hiroppe);
        //153sec待つ
        yield return new WaitForSeconds(153);
    }
}
