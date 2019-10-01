using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    public RectTransform UI;
    public bool CanGoToInventory;
    public bool CanOpenInventory;
    public bool IsAnAnimal;
    Inventory inventory;

    RectTransform newPos;

    void Start()
    {
        inventory = Inventory.instance;
    }

    public void DoInteraction(GameObject playerInteracted)
    {
        if (this.CanGoToInventory)
        {
            inventory.Add(playerInteracted);
            SetGameObject(playerInteracted);
        }
        if (this.CanOpenInventory)
        {
            ShowCanvas();
        }
    }

    private void SetGameObject(GameObject playerInteracted)
    {
        playerInteracted.SetActive(false);
    }

    public void ShowCanvas()
    {
        var position = UI.position;
        position.x = 136f;
        UI.position = position;
    }
    
    public void HideCanvas()
    {
        var position = UI.position;
        position.x = -132f;
        UI.position = position;
    }
}
