// J & Angelo 2019
// For Domesticate Hell 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField]
    private GameObject StoreDeHell;

    public GameObject InventoryUI;
    public GameObject currentInteractionObject = null;
    public GameObject nameEnviroment = null;
    public GameObject gameObjectInventory = null;
    public GameObject onStair = null;
    public InteractionObject currentInteractionScript = null;
    public Player_Climb playerInteractionStair = null;
    public Inventory inventory;
    public bool AtStore = false;
    public bool StoreOnDisplay = false;

    void Update()
    {
        // Is Player trying to interact
        if (Input.GetButtonDown("Interact") || Input.GetButton("Interact"))
        {
            Debug.Log("Player is attempting to interact");
            // Check if the player is at the store 
            if (AtStore == true) // Player at the store 
            {
                // Check if the store is on display 
                if (StoreOnDisplay == false) // Store is not on display 
                {
                    StoreDeHell.SetActive(true); // Turn on StoreDeHell canvas 
                    StoreOnDisplay = true;
                } 
                else if (StoreOnDisplay == true) // Store is on display
                {
                    StoreDeHell.SetActive(false); // Turn off StoreDeHell Canvas
                    StoreOnDisplay = false; 
                }
            } 

            if (currentInteractionObject)
            {
                currentInteractionScript.DoInteraction(currentInteractionObject);
            }
            else if (gameObjectInventory)
            {
                currentInteractionScript.DoInteraction(gameObjectInventory);
            } 
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

        if (Input.GetButtonDown("Cancel") || Input.GetButton("CloseInventory"))
        {
            currentInteractionScript.HideCanvas();
        }

        
    }

    // Entering collider trigger
    void OnTriggerEnter2D(Collider2D x)
    {
        if(x.CompareTag("StoreDeHell"))
        {
            Debug.Log("Entered Store de Hell!");
            AtStore = true;
        }
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
            gameObjectInventory = x.gameObject;
            currentInteractionScript = gameObjectInventory.GetComponent<InteractionObject>();
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

    // Exiting collider trigger
    void OnTriggerExit2D(Collider2D x) 
    {
        // exiting Store de Hell?
        if (x.CompareTag("StoreDeHell"))
        {
            // set AtStore to false if exiting Store de Hell
            Debug.Log("Leaving Store de Hell!");
            AtStore = false;
        }
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
            if (x.gameObject == gameObjectInventory)
            {
                gameObjectInventory = null;
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
