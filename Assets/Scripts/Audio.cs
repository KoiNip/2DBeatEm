using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("master", volume);
    }

    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }

    public void setEffectVolume(float volume)
    {
        audioMixer.SetFloat("sfx", volume);
    }
}
