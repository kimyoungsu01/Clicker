using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSource; // ������� ����� �ҽ�
    public AudioSource sfxSource; // ȿ���� ����� �ҽ�
    public AudioSource UpdatesfxSource; // ȿ���� ����� �ҽ�

    public static SoundManager instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        
    }
}
