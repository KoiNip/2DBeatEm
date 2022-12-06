/*
 * File: audio.cs
 * Author - Ryan Phan
 * Class - CS 4700 Game Development
 * Assignment - Program 4
 * Date Last Modified: 12/5/2022
 * 
 * Purpose: Audio controller for the volume setting sliders.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer audioMixer;

    //Slider for the master mixer
    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("master", volume);
    }

    //Slider for the music mixer
    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }

    //Slider for the SFX mixer
    public void setEffectVolume(float volume)
    {
        audioMixer.SetFloat("sfx", volume);
    }
}
