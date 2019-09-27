using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public new string name = "New Item";
    public GameObject UI;
    public Sprite icon;
    public bool invetory;
    public bool CanOpenInventory;

    private void Start()
    {
        name = this.gameObject.name;
    }

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

    public void EnableCanvas()
    {
        UI.SetActive(true);
    }
    
    public void DisableCanvas()
    {
        UI.SetActive(false);
    }
}
