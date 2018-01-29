using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource blockSound;

    private bool isBlockSoundPlaying = false;

    // Use this for initialization
    void Awake()
    {
        instance = this;
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
