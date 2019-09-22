using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_Object : MonoBehaviour
{
    public bool inventory_bool; //If true this object can be stored in inventory;
    public bool animal_bool;
    public bool computer_bool;
    bool inventory_open;
    public GameObject inventory;

    public void doInteraction()
    {
        if (gameObject.CompareTag("Item"))
        {
            gameObject.SetActive(false);
        }
        else if (gameObject.CompareTag("Food"))
        {
            gameObject.SetActive(false);
        }
        else if (gameObject.CompareTag("Computer"))
        {
            if (!inventory_open)
            {
                enableInventory();
            }
        }
    }

    void enableInventory()
    {
        inventory.SetActive(true);
    }

    void disableInventory()
    {
        inventory.SetActive(false);
    }
}
