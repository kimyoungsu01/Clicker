using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSource; // ������� ����� �ҽ�
    public AudioSource sfxSource; // ȿ���� ����� �ҽ�

    public void setMusicVolum(float volume) 
    {
        bgmSource.volume = volume;
    }

    public void OnSfx() 
    {
        sfxSource.Play();
    }
}
