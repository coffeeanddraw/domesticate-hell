using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;  // The entire UI
    public Transform itemsParent;   // The parent object of all the items

    Inventory inventory;	// Our current inventory

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    //void Update()
    //{
    //    //UpdateUI();
    //}

    public void UpdateUI()
    {
        Debug.Log("UPDATING UI");
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            //Debug.Log(inventory.items.Count);

            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                Debug.Log("TEst1");
            }
            //else
            //{
            //    Debug.Log("TEst2");
            //    slots[i].ClearSlot();
            //}
        }
    }
}
