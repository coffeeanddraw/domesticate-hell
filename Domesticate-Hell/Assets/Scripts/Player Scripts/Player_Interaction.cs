using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject currentInteractionObject = null;
    public GameObject nameEnviroment = null;
    public GameObject onStair = null;
    public InteractionObject currentInteractionScript = null;
    public Player_Climb playerInteractionStair = null;
    public Inventory inventory;

    void Update()
    {

        if (Input.GetButtonDown("Interact") && currentInteractionObject)
        {
            currentInteractionScript.DoInteraction(currentInteractionObject);
        }

        if(Input.GetKey("s") && onStair || Input.GetAxis("VerticalDown") >= 1 && onStair)
        {
            playerInteractionStair.isClimbing = true;
            playerInteractionStair.ClimbDown();
        }
        else if (Input.GetKey("w") && onStair || Input.GetAxis("VerticalUp") == -1 && onStair)
        {
            playerInteractionStair.isClimbing = true;
            playerInteractionStair.ClimbUp();
        }
        else if(onStair)
        {
            playerInteractionStair.StopClimbing();
        }
        else if (nameEnviroment)
        {
            playerInteractionStair.StopClimbing2();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            currentInteractionScript.HideCanvas();
        }

        
    }

    void OnTriggerEnter2D(Collider2D x)
    {
        if (x.CompareTag("Food"))
        {
            Debug.Log(x.name);
            currentInteractionObject = x.gameObject;
            currentInteractionScript = currentInteractionObject.GetComponent<InteractionObject>();
        }
        else if (x.CompareTag("Item"))
        {
            Debug.Log(x.name);
            currentInteractionObject = x.gameObject;
            currentInteractionScript = currentInteractionObject.GetComponent<InteractionObject>();
        }
        else if (x.CompareTag("Animal"))
        {
            Debug.Log(x.name);
            currentInteractionObject = x.gameObject;
            currentInteractionScript = currentInteractionObject.GetComponent<InteractionObject>();
        }
        else if (x.CompareTag("AI"))
        {
            Debug.Log(x.name);
            currentInteractionObject = x.gameObject;
            currentInteractionScript = currentInteractionObject.GetComponent<InteractionObject>();
        }
        else if (x.CompareTag("Stair"))
        {
            Debug.Log(x.name);
            onStair = x.gameObject;
            currentInteractionScript = onStair.GetComponent<InteractionObject>();
        }
        else if (x.CompareTag("Enviroment"))
        {
            Debug.Log(x.name);
            nameEnviroment = x.gameObject;
            currentInteractionScript = nameEnviroment.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit2D(Collider2D x)
    {
        if (x.CompareTag("Food"))
        {
            if (x.gameObject == currentInteractionObject)
            {
                currentInteractionObject = null;
            }
        }
        else if (x.CompareTag("Item"))
        {
            if (x.gameObject == currentInteractionObject)
            {
                currentInteractionObject = null;
            }
        }
        else if (x.CompareTag("Animal"))
        {
            if (x.gameObject == currentInteractionObject)
            {
                currentInteractionObject = null;
            }
        }
        else if (x.CompareTag("AI"))
        {
            if (x.gameObject == currentInteractionObject)
            {
                currentInteractionObject = null;
            }
        }
        else if (x.CompareTag("Stair"))
        {
            if (x.gameObject == onStair)
            {
                onStair = null;
            }
        }
        else if (x.CompareTag("Enviroment"))
        {
            if (x.gameObject == nameEnviroment)
            {
                nameEnviroment = null;
            }
        }
    }
}
