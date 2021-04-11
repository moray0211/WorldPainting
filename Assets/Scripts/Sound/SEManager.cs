using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void changeAudioClip(AudioClip ac)
    {
        audioSource.clip = ac;
    }

    public void playAudioClip()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void playAudioClip(AudioClip ac)
    {
        audioSource.clip = ac;
        audioSource.PlayOneShot(ac);
    }

    public void stopAllAudioClip()
    {
        audioSource.Stop();
    }
}
