using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        animator.GetComponent<Animator>();
        animator.SetBool("Death", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CountdownTimer.instance.TimeLeft <= 0)
        {
            ShowDeathScreen();
        }


    }

    public void ShowDeathScreen()
    {
        animator.SetBool("Death", true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
