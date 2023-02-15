using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTargetTrigger : MonoBehaviour
{
    public GameObject Door;
    public Animator animator;

    [SerializeField] int targetsDestroyed;
    [SerializeField] int MaxTarget;

    // Start is called before the first frame update
    void Start()
    {
        targetsDestroyed = 0;
        animator.GetComponent<Animator>();
    }

    public void TargetDestroyed()
    {
        targetsDestroyed++;
    }

    // Update is called once per frame
    void Update()
    {
        
        

        

        if(targetsDestroyed >= MaxTarget)
        {
            animator.SetBool("Opened", true);
        }

    }
}
