using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip aClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }


    public void PlayASource()
    {
        audioSource.PlayOneShot(aClip);
    }

}
