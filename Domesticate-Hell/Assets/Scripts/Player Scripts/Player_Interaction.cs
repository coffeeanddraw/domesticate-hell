using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject currentInteractionObject = null;
    public InteractionObject currentInteractionScript = null;
    public Inventory inventory;

    void Update()
    {

        if (Input.GetButtonDown("Interact") && currentInteractionObject)
        {
            currentInteractionScript.DoInteraction(currentInteractionObject);
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
    }
}
