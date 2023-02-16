using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SFXVolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer = null;

    [SerializeField] private Slider _slider;

    void Start()
    {
        _slider.GetComponent<Slider>();
        _slider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", 0));
    }

    public void SetVolume(float Value)
    {
        PlayerPrefs.SetFloat("SFXVolume", Value);
        PlayerPrefs.Save();
        audioMixer.SetFloat("SFXVolume", Value);
    }
}
