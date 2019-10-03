using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public int space = 16;
    public List<GameObject> items;
    public GameObject inventoryUI;

    void Start()
    {
        items = new List<GameObject>();
    }

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
    }

    // Remove an item
    public void Remove(GameObject item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public GameObject searchItem()
    {
       GameObject item =  items.Where(x => x.tag == "Food").SingleOrDefault();
       return item;
    }
}
