// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    private GameObject storeItem;

    [SerializeField]
    private bool ticket = false;

    [SerializeField]
    private bool food = false;

    [SerializeField]
    private int price;

    void Purchase()
    {
        if (GameManager.SoulCount >= price)
        {
            GameManager.SoulCount -= price;
        }
    }
}
