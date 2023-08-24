using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public Sound [] sound;
    public static AudioManager instance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        } 
        foreach(Sound s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
    }
    void Start()
    {
        PlaySound("them");
    }

    public void PlaySound(string name)
    {
        Sound s =Array.Find(sound,sound=>sound.name == name);
        if(s == null)
        {
            Debug.LogError("Sound not found");
            return;
        }
        s.source.Play();
    }
}
