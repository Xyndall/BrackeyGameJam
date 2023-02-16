using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    bool isPaused;

    public GameObject PauseCanvas;
    public GameObject WinCanvas;

    public GameObject Timer;

    public AudioSource MusicASource;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        WinCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //close inventory
                ResumeGame();

            }
            else
            {
                //openInventory
                PauseGame();

            }
        }
    }

    public void Win()
    {
        WinCanvas.SetActive(true);
        CountdownTimer.instance.TimerOn = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        isPaused = false;
        MusicASource.Play();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        PauseCanvas.SetActive(false);
    }

    public void PauseGame()
    {
        isPaused = true;
        MusicASource.Pause();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        PauseCanvas.SetActive(true);
    }
}
