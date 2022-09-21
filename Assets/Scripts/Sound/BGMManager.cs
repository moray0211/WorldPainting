using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    public AudioSource audioSource;
    public AudioClip CurrentAudioClip;
    public AudioClip[] ThemeClip;

    void changeAudioClip(AudioClip ac)
    {
        if (audioSource.isPlaying) audioSource.Stop();
        CurrentAudioClip = ac;
        audioSource.clip = CurrentAudioClip;
        audioSource.Play();
    }

    public void playAudioClip()
    {
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.Play();
    }

    public void PlayTheme(int themeNumber)
    {
        changeAudioClip(ThemeClip[themeNumber]);
    }

}
