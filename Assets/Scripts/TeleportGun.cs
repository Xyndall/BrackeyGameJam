using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TeleportGun : MonoBehaviour
{
    public GameObject player;

    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.1f;
    public float PullStength = 20;


    LineRenderer laserLine;
    float fireTimer;

    Transform hitMarker;
    bool beingPulled;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        

        fireTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse1) && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                
                hitMarker = hit.transform;
                beingPulled = true;
                
                //Destroy(hit.transform.gameObject);
            }
            else
            {
                beingPulled = false;
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
                player.GetComponent<CharacterMovement>().gravity = -9.8f;
            }
            StartCoroutine(ShootLaser());
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            player.GetComponent<CharacterMovement>().gravity = -9.8f;
            beingPulled = false;
        }

        if (beingPulled)
        {
            PullPlayer();
        }

    }

    public void PullPlayer()
    {
        laserLine.SetPosition(1, hitMarker.position);
        player.GetComponent<CharacterMovement>().gravity = 0;
        player.transform.position += (hitMarker.transform.position - player.transform.position) * PullStength * Time.deltaTime;
    }


    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
