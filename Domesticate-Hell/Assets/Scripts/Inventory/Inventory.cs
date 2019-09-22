using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventoryItem = new List<GameObject>();
    public List<GameObject> inventoryFood = new List<GameObject>();

    public void addAnyItemToInventory(GameObject other)
    {
        if (other.CompareTag("Item"))
        {
            inventoryItem.Add(other);
            Debug.Log("Item Added");
            other.SendMessage("doInteraction");
        }
        else if (other.CompareTag("Food"))
        {
            inventoryFood.Add(other);
            Debug.Log("Item Added");
            other.SendMessage("doInteraction");
        }        
    }

    public void removeFirstFoodFromTheInventory()
    {
        inventoryFood.RemoveAt(0);
    }
}
