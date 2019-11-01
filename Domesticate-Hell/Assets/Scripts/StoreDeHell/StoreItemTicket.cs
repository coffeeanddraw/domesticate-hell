// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemTicket : MonoBehaviour
{
    [SerializeField]
    private GameObject storeItem;

    [SerializeField]
    private GameObject unlockedMask;

    [SerializeField]
    private GameObject purchaseButton;

    [SerializeField]
    private GameObject insufficientFundsUI;

    [SerializeField]
    private GameObject thankYouForYourPurchaseUI;

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

    [SerializeField]
    private AudioClip[] thankYouSound = new AudioClip[2];

    [Header("Key Image Game Objects ")]
    [SerializeField]
    private Image fireKey;
    [SerializeField]
    private Image shadowKey;
    [SerializeField]
    private Image electricityKey;
    [SerializeField]
    private Image alchemyKey;

    [Header("Activated Key Sprites ")]
    [SerializeField]
    private Sprite fireKeyActivated;
    [SerializeField]
    private Sprite shadowKeyActivated;
    [SerializeField]
    private Sprite electricKeyActivated;
    [SerializeField]
    private Sprite alchemyKeyActivated;


    private bool unlocked = false;

    private AudioSource insufficientFundsVoice;

    private AudioSource purchaseSoundEffect;

    private AudioSource thankYouForYourPurchaseVoice;

    void Awake()
    {

        insufficientFundsVoice = insufficientFundsUI.GetComponent<AudioSource>();
        thankYouForYourPurchaseVoice = thankYouForYourPurchaseUI.GetComponent<AudioSource>();
        
        this.purchaseButton.SetActive(true);
        insufficientFundsUI.SetActive(false);
        thankYouForYourPurchaseUI.SetActive(false);
        this.unlockedMask.SetActive(false);
        this.pet.SetActive(false);
    }


    public void Purchase()
    {
        Debug.Log("Player is attempting to purchase a ticket");
        if (GameManager.SoulCount >= price)
        {
            if (fireTicket)
            {
                GameManager.HasFireKey = true;
                fireKey.sprite = fireKeyActivated;
                PurchasePets();
            }
            else if (shadowTicket)
            {
                GameManager.HasShadowKey = true;
                shadowKey.sprite = shadowKeyActivated;
                PurchasePets();
            }
            else if (electricityTicket)
            {
                GameManager.HasElectricityKey = true;
                electricityKey.sprite = electricKeyActivated;
                PurchasePets();
            }
            else if (alchemyTicket)
            {
                GameManager.HasAlchemyKey = true;
                alchemyKey.sprite = alchemyKeyActivated;
                PurchasePets();
            }

            this.unlockedMask.SetActive(true);
            GameManager.SoulCount -= price;
            unlocked = true;
        }
        else if (GameManager.SoulCount < price )
        {
            if (insufficientFundsUI != null)
            {
                insufficientFundsUI.SetActive(true);
                PlayInsufficientFundsVoice();
                Invoke("CloseInsufficientFundsUI", 3);
            }
        }
    }

    void InstantiatePet()
    {
        pet.SetActive(true);
    }

    void PlayInsufficientFundsVoice()
    {
        insufficientFundsVoice.Play();
    }

    void CloseInsufficientFundsUI()
    {
        insufficientFundsUI.SetActive(false);
    }

    void CloseThankYouForYourPurchaseUI()
    {
        thankYouForYourPurchaseUI.SetActive(false);
    }

    void PurchasePets()
    {
        InstantiatePet();
        thankYouForYourPurchaseUI.SetActive(true);
        PlayThankYouSound(0);
        PlayThankYouSound(1);
        Invoke("CloseThankYouForYourPurchaseUI", 3);
    }

    void PlayThankYouSound(int newClip)
    {
        thankYouForYourPurchaseVoice.PlayOneShot(thankYouSound[newClip]);
    }
}


