using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public static SoundManager instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
        else if (instance != null)
        {
           Destroy(gameObject);
        }
    }

    public void ChangeBGM(AudioClip newBGM)
    {
        if (_audioSource.clip == newBGM) return; // 같은 음악이면 무시
        _audioSource.clip = newBGM;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
