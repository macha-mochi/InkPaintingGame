using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetup : MonoBehaviour
{
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;
    private void Start()
    {
        music.value = AudioManager.musicVolume;
        sfx.value = AudioManager.sfxVolume;
    }
    public void Music(float f)
    {
        AudioManager.Instance.UpdateMusicVolume(f);
    }
    public void SFX(float f) 
    {
        AudioManager.Instance.UpdateSFXVolume(f);
    }
}
