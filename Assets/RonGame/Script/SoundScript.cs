using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips = new AudioClip[4];
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(int index)
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(audioClips[index]);
    }
}
