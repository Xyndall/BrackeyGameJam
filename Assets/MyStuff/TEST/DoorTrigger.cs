using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject Door;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OBJ"))
        {
            Debug.Log("Entered");
            animator.SetBool("Opened", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OBJ"))
        {
            Debug.Log("Exited");
            animator.SetBool("Opened", false);
        }
    }

}
