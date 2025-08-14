using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get { return instance; }
    }
    private AudioSource musicSource;
    private AudioSource[] audioSources;
    WriterAudio fungusAudio;

    public static float musicVolume = 0.25f;
    public static float sfxVolume = 1f;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        audioSources = new AudioSource[0];
    }
    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }
    public void UpdateMusicVolume(float vol)
    {
        musicSource.volume = vol;
        musicVolume = vol;
    }
    public void UpdateSFXVolume(float vol)
    {
        //Debug.Log("num audio sources: " + audioSources.Length);
        foreach(AudioSource a in audioSources)
        {
            if(a != musicSource && a != null)
            {
                a.volume = vol;
            }
        }
        if (fungusAudio != null)
        {
            fungusAudio.SetVolume(vol);
            //Debug.Log("fungus sfx volume: " + vol);
        }
        sfxVolume = vol;
    }
    public void UpdateAudioSourceList() //to be called whenever settings are opened
    {
        audioSources = FindObjectsOfType<AudioSource>(true);
        fungusAudio = FindObjectOfType<WriterAudio>();
    }

}
