using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer = null;
    public string paramName;
    [SerializeField] private Slider _slider;

    void Start()
    {
        _slider.GetComponent<Slider>();
        _slider.value = PlayerPrefs.GetFloat(paramName, 0);
        audioMixer.SetFloat(paramName, PlayerPrefs.GetFloat(paramName, 0));
    }

    public void SetVolume()
    {
        PlayerPrefs.SetFloat(paramName, _slider.value);
        PlayerPrefs.Save();
        audioMixer.SetFloat(paramName, _slider.value);
    }
}
