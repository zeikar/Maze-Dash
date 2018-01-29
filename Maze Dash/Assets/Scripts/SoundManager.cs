using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource blockSound;
    public AudioSource backgroundMusic;
    public AudioSource gameOverSound, gameClearSound;

    private bool isBlockSoundPlaying = false;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public void PlayGameOverSound()
    {
        gameOverSound.Play();
    }

    public void PlayGameClearSound()
    {
        gameClearSound.Play();
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }
    
    public void PlayBlockSound()
    {
        if(isBlockSoundPlaying)
        {
            return;
        }

        blockSound.Play();
        isBlockSoundPlaying = true;
    }

    public void StopBlockSound()
    {
        isBlockSoundPlaying = false;
        blockSound.Stop();
    }
}
