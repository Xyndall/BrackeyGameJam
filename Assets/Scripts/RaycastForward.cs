using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForward : MonoBehaviour
{
    #region singleton
    public static RaycastForward instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    [SerializeField] Transform raycastTarget;
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject winText;

    public float hitDistance = 2;

    public bool hittingObject;
    public bool hittingWin;
    public bool HoldingTarget = false;
    public LayerMask interactableObjects;
    public LayerMask WinObjects;

    GameObject targetInteractable;

    Vector3 fwd;

    private void Start()
    {
        HoldingTarget = false;
    }

    private void FixedUpdate()
    {
         fwd = raycastTarget.position - transform.position;
        
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, hitDistance, interactableObjects))
        {
            hittingObject = true;
            if (!HoldingTarget)
            {
                interactText.SetActive(true);
                targetInteractable = hit.transform.gameObject;
            }

        }
        else
        {
            
            hittingObject = false;
            interactText.SetActive(false);
            
        }

        if (Physics.Raycast(transform.position, fwd, out hit, hitDistance, WinObjects))
        {
            hittingWin = true;
            winText.SetActive(true);

        }
        else
        {
            hittingWin = false;
            winText.SetActive(false);
        }

        Debug.DrawLine(transform.position, transform.position + fwd * hitDistance, Color.yellow);

    }


    private void Update()
    {

        if (hittingObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (HoldingTarget)
                {
                    
                    targetInteractable.GetComponent<PickupObject>().Drop(fwd);
                    HoldingTarget = false;
                }
                else
                {
                    interactText.SetActive(false);
                    targetInteractable.GetComponent<PickupObject>().Pickup(raycastTarget);
                    HoldingTarget = true;
                }
                

            }
            

        }

        if (hittingWin)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.Win();
            }
        }

    }

    

}
