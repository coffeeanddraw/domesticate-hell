using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    GameObject item;  // Current item in the slot

    // Add item to the slot
    public void AddItem(GameObject newItem)
    {
        icon.sprite = newItem.GetComponent<SpriteRenderer>().sprite;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(item);
    }

}
