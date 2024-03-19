using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClipsQuestion = new AudioClip[4];
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        if (!audioSource) audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(audioClipsQuestion[index]);
    }
}
