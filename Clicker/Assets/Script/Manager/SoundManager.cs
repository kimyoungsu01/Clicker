using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSource; // 배경음악 오디오 소스
    public AudioSource StatbgmSource; // 배경음악 오디오 소스
    public AudioSource sfxSource; // 효과음 오디오 소스
    public AudioSource UpdatesfxSource; // 효과음 오디오 소스

    public static SoundManager instance { get; set; }

    private void Awake()
    {       
            instance = this;
            
            if (bgmSource == null) bgmSource = gameObject.AddComponent<AudioSource>();
            if (sfxSource == null) sfxSource = gameObject.AddComponent<AudioSource>();
            if (StatbgmSource == null) StatbgmSource = gameObject.AddComponent<AudioSource>();
            if (UpdatesfxSource == null) UpdatesfxSource = gameObject.AddComponent<AudioSource>();       
    }

    public void setMusicVolum(float volume) 
    {
        bgmSource.volume = volume;
    }

    public void OnSfx(float sfxvolume) 
    {
        sfxSource.volume = sfxvolume;
        sfxSource.Play();
    }

    public void OnStatbgm(float statbgmvolume) 
    {
        StatbgmSource.volume = statbgmvolume;        
    }

    public void OnStatSFX(float statsfxvolume)
    { 
        UpdatesfxSource.volume = statsfxvolume;
        UpdatesfxSource.Play();
    }

    public void OnUpdatesfx() 
    {
        UpdatesfxSource.Play();
    }
}
