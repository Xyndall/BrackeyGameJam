using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public bool isDestroyed;

    public GameObject Door;

    private void Start()
    {
        isDestroyed = false;
    }
    public void TargetHit()
    {
        isDestroyed = true;
        Door.GetComponent<DoorTargetTrigger>().TargetDestroyed();
        Destroy(gameObject);
    }



}
