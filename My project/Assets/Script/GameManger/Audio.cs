using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{   
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXlaser;
    [Header("Audio Clip")]
    [SerializeField]public AudioClip musicClip;
    [SerializeField]public AudioClip DeathClip;
    [SerializeField]public AudioClip HitClip;
    [SerializeField]public AudioClip ShootClip;
    [SerializeField]public AudioClip EnemydamageClip;
    [SerializeField]public AudioClip poewelClip;
    [SerializeField]public AudioClip ShotGunClip;
    [SerializeField]public AudioClip HealthClip;
    [SerializeField]public AudioClip UpgradeGunClip;
    [SerializeField]public AudioClip ErrorClip;
    //Shotgun and Bomb sound soon
    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }
    public void PlayMusic(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
     public void PlayMusiclaser(AudioClip clip)
    {
        SFXlaser.PlayOneShot(clip);
    }
}
