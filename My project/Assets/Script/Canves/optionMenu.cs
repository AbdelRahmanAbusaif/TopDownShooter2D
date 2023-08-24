using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionMenu : MonoBehaviour
{
    public Slider VoulumeSlider;  
    public Slider MusicSlider;
    public Slider SFXslider;
    public AudioMixer myaudioMixer;
    void start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            Load();
        }
        else 
           SetMusicVolume();

    }
     
    void Load()
    {
        MusicSlider.value=PlayerPrefs.GetFloat("music");
        MusicSlider.value=PlayerPrefs.GetFloat("volume");
        MusicSlider.value=PlayerPrefs.GetFloat("sfx");
    }
    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        myaudioMixer.SetFloat("music", MathF.Log10(volume)*20);
        PlayerPrefs.SetFloat("music",volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXslider.value;
        myaudioMixer.SetFloat("sfx", MathF.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfx",volume);
    }
    public void SetVolumeVolume()
    {
        float volume = VoulumeSlider.value;
        myaudioMixer.SetFloat("volume", MathF.Log10(volume)*20);
        PlayerPrefs.SetFloat("volume",volume);
    }
}
