using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wattahgame_SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<wattahgameBGMSoundData> bgmSoundDatas;
    [SerializeField] List<wattahgameSESoundData> seSoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    public static wattahgame_SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(wattahgameBGMSoundData.BGM bgm)
    {
        wattahgameBGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }


    public void PlaySE(wattahgameSESoundData.SE se)
    {
        wattahgameSESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

}

[System.Serializable]
public class wattahgameBGMSoundData
{
    public enum BGM
    {
        Title,
        Dungeon,
        Hoge, // これがラベルになる
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class wattahgameSESoundData
{
    public enum SE
    {
        Attack,
        Damage,
        Hoge,
        Pose, // これがラベルになる
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}
