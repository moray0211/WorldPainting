using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void changeAudioClip(AudioClip ac)
    {
        audioClip = ac;
    }

    public void playAudioClip()
    {
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.Play();
    }

}
