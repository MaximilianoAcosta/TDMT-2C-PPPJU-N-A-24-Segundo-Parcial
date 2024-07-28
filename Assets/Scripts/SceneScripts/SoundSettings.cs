using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer audioMixer;
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    private void SetVolume(float v)
    {
        if(v <1)
        {
            v = 0.001f;
        }
        RefreshSlider(v);
        PlayerPrefs.SetFloat("SavedMasterVolume", v);
        audioMixer.SetFloat("MasterVolume",Mathf.Log10(v/100) * 20f);
    }

    private void RefreshSlider(float v)
    {
        if (soundSlider.IsActive())
        {
            soundSlider.value = v;
        }
    }
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }
}
