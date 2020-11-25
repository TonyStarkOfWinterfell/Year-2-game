using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public ItemStash stashy;

    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned AudioManager", typeof(SoundManager)).GetComponent<SoundManager>();

                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }       //Private?
    }

    //private AudioSource musicSource;
    private AudioSource sfxSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //musicSource = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();
    }      

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);

    }
    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip,volume);
    }
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }


}


//on added to script drag in sfx - inspector
/*
 
[SerializeField] private AudioClip buttonClickSFX;
SoundManager.Instance.PlaySFX(buttonClickSFX, 1);

    */
