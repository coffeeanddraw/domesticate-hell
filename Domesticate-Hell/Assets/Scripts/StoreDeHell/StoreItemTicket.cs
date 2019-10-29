// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemTicket : MonoBehaviour
{
    [SerializeField]
    private GameObject storeItem;

    [SerializeField]
    private GameObject unlockedMask;

    [SerializeField]
    private GameObject purchaseButton;

    [SerializeField]
    private GameObject InsufficientFundsUI;

    [SerializeField]
    private GameObject petSpawnLocation;

    [SerializeField]
    private GameObject pet;

    [SerializeField]
    private bool fireTicket;

    [SerializeField]
    private bool shadowTicket;

    [SerializeField]
    private bool electricityTicket;

    [SerializeField]
    private bool alchemyTicket;

    [SerializeField]
    private int price;

    private bool unlocked = false;

    private AudioSource insufficientFundsVoice;

    public void Awake()
    {

        insufficientFundsVoice = InsufficientFundsUI.GetComponent<AudioSource>();
        this.purchaseButton.SetActive(true);
        InsufficientFundsUI.SetActive(false);
        this.unlockedMask.SetActive(false);
    }


    public void Purchase()
    {
        Debug.Log("Player is attempting to purchase the item");
        if (GameManager.SoulCount >= price)
        {
            if (fireTicket)
            {
                GameManager.HasFireKey = true;
                InstantiatePet();
            }
            else if (shadowTicket)
            {
                GameManager.HasShadowKey = true;
                InstantiatePet();
            }
            else if (electricityTicket)
            {
                GameManager.HasElectricityKey = true;
                InstantiatePet();
            }
            else if (alchemyTicket)
            {
                GameManager.HasAlchemyKey = true;
                InstantiatePet();
            }

            this.unlockedMask.SetActive(true);
            GameManager.SoulCount -= price;
            unlocked = true;
        }
        else if (GameManager.SoulCount < price )
        {
            if (InsufficientFundsUI != null)
            {
                InsufficientFundsUI.SetActive(true);
                playInsufficientFundsVoice();
                Invoke("closeInsufficientFundsUI", 3);
            }
        }
    }

    void InstantiatePet()
    {

    }

    void playInsufficientFundsVoice()
    {
        insufficientFundsVoice.Play();
    }

    void closeInsufficientFundsUI()
    {
        InsufficientFundsUI.SetActive(false);
    }
}
