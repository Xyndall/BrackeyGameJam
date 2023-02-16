using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{

    public GameObject PlayerGun;
    public GameObject TeleportGun;


    // Start is called before the first frame update
    void Start()
    {
        PlayerGun.SetActive(false);   
        TeleportGun.SetActive(false);   

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GunPickUp"))
        {
            Debug.Log("Gun Picked Up");
            Destroy(other.gameObject);
            PlayerGun.SetActive(true);
        }

        if (other.CompareTag("TeleportGun"))
        {
            Debug.Log("Gun Picked Up");
            Destroy(other.gameObject);
            TeleportGun.SetActive(true);
        }
    }

}
