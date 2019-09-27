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

    public int space = 16;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<GameObject> items = new List<GameObject>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // Add a new item if enough room
    public void Add(GameObject item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        
        item.SendMessage("DoInteraction");
    }

    // Remove an item
    public void Remove(GameObject item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
