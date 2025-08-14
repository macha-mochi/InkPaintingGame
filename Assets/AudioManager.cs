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
    }
    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        UpdateAudioSourceList();
    }
    public void UpdateMusicVolume(float vol)
    {
        musicSource.volume = vol;
        Debug.Log("music volume: " + vol);
    }
    public void UpdateSFXVolume(float vol)
    {
        foreach(AudioSource a in audioSources)
        {
            if(a != musicSource)
            {
                a.volume = vol;
            }
        }
        Debug.Log("sfx volume: " + vol);
        //fungusAudio = FindObjectOfType<WriterAudio>();
        if (fungusAudio != null)
        {
            fungusAudio.SetVolume(vol);
            Debug.Log("fungus sfx volume: " + vol);
        }
    }
    public void UpdateAudioSourceList() //to be called by main manager after setting up each location
    {
        audioSources = FindObjectsOfType<AudioSource>();
        fungusAudio = FindObjectOfType<WriterAudio>();
    }

}
