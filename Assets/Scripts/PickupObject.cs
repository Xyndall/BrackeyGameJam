using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    bool BeingHeld;
    Transform heldpos;

    private void Start()
    {
        BeingHeld = false;
    }

    public void Pickup(Transform target)
    {
        Debug.Log("Trying to pickup");
        rb.GetComponent<Rigidbody>();
        rb.useGravity = false;
        BeingHeld = true;
        heldpos = target;
       
    }

    private void Update()
    {
        if (BeingHeld)
        {
            transform.position = heldpos.position;
        }

    }

    public void Drop(Vector3 dir)
    {
        Debug.Log("Trying to Drop");
        rb.GetComponent<Rigidbody>();
        rb.useGravity = true;
        BeingHeld = false;
        rb.GetComponent<Rigidbody>().velocity = dir * 2;

    }

}
