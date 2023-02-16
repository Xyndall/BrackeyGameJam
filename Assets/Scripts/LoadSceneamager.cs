using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneamager : MonoBehaviour
{
    #region singleton
    public static LoadSceneamager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene(0);
    }


}
