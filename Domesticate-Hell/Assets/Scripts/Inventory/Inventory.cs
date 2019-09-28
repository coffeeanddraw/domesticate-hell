using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    internal static Inventory instance;

    void Awake()
    {
        instance = this;   
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 16;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<GameObject> items = new List<GameObject>();

    public GameObject inventoryUI;


    // Add a new item if enough room
    public void Add(GameObject item)
    {
        if (item.GetComponent<InteractionObject>().invetory)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            items.Add(item);

            inventoryUI.gameObject.GetComponent<InventoryUI>().UpdateUI();     

            item.SendMessage("DoInteraction");
        }
    }

    // Remove an item
    public void Remove(GameObject item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
