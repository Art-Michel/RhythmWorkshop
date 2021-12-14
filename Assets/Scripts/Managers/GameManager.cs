using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : LocalManager<GameManager>
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioSource musicSource;

    private void Start() 
    {
        Time.timeScale = 1;
        musicSource.clip = music;    
    }

    [Button]
    void PlayMusic()
    {
        musicSource.Play();
    }

    [Button]
    void PauseMusic()
    {
        musicSource.Pause();
    }
}