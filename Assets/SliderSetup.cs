using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSetup : MonoBehaviour
{
    public void Music(float f)
    {
        AudioManager.Instance.UpdateMusicVolume(f);
    }
    public void SFX(float f) 
    {
        AudioManager.Instance.UpdateSFXVolume(f);
    }
}
