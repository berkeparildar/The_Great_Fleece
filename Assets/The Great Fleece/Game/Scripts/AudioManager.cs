using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public AudioSource voiceOver;
    public AudioSource music;
    
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Audio manager is null.");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clip)
    {
        voiceOver.clip = clip;
        voiceOver.Play();
    }

    public void PlayMusic()
    {
        music.Play();
    }
    
}
