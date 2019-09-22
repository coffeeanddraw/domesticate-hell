using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField] private GameObject currentInterObject = null;
    private Interactive_Object currentInterObjectScritp = null;
    public Inventory inventory;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObject)
        {
            if (currentInterObjectScritp.inventory_bool)
            {
                inventory.addAnyItemToInventory(currentInterObject);
            }

            if (currentInterObjectScritp.animal_bool)
            {
                inventory.removeFirstFoodFromTheInventory();
            }
        }

        if(Input.GetButtonDown("Interact") && currentInterObjectScritp.computer_bool)
        {
            currentInterObject.SendMessage("doInteraction");
        }

        if (Input.GetButtonDown("CloseInventory"))
        {
            currentInterObjectScritp.inventory.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Item");
            currentInterObject = other.gameObject;
            currentInterObjectScritp = currentInterObject.GetComponent<Interactive_Object>();
        }
        else if (other.CompareTag("Food"))
        {
            Debug.Log("Food");
            currentInterObject = other.gameObject;
            currentInterObjectScritp = currentInterObject.GetComponent<Interactive_Object>();
        }
        else if (other.CompareTag("Animal"))
        {
            Debug.Log("Animal");
            currentInterObject = other.gameObject;
            currentInterObjectScritp = currentInterObject.GetComponent<Interactive_Object>();
        }
        else if (other.CompareTag("Computer"))
        {
            Debug.Log("Computer");
            currentInterObject = other.gameObject;
            currentInterObjectScritp = currentInterObject.GetComponent<Interactive_Object>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item") || other.CompareTag("Food") || other.CompareTag("Animal"))
        {
            currentInterObject = null;
        }
    }
}
