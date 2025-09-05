using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSource; // 배경음악 오디오 소스
    public AudioSource sfxSource; // 효과음 오디오 소스
    public AudioSource UpdatesfxSource; // 효과음 오디오 소스

    public static SoundManager instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponents<AudioSource>()[0].GetComponent<SoundManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setMusicVolum(float volume) 
    {
        bgmSource.volume = volume;
    }

    public void OnSfx() 
    {
        sfxSource.Play();
    }

    public void OnUpdatesfx() 
    {
        UpdatesfxSource.Play();
    }
}
