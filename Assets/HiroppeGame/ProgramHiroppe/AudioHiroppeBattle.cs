using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHiroppeBattle : MonoBehaviour
{
    public AudioSource audioSourcebattlehiroppe;
    public AudioClip SE3hiroppe;


    // Start is called before the first frame update
    void Start()
    {
        audioSourcebattlehiroppe = GetComponent<AudioSource>();
        StartCoroutine("Soundhiroppebattle");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Soundhiroppebattle()
    {
        audioSourcebattlehiroppe.PlayOneShot(SE3hiroppe);
        //138sec待つ
        yield return new WaitForSeconds(138);
    }
}
