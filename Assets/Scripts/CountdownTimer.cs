using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    #region singleton
    public static CountdownTimer instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public AudioSource aSource;
    [SerializeField] AudioClip aClip;

    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerTxt;
    bool audioPllaying;
    void Start()
    {
        TimerOn = true;
        aSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }

        if(TimeLeft <= 6 && !audioPllaying )
        {
            audioPllaying = true;
            aSource.PlayOneShot(aClip);
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
