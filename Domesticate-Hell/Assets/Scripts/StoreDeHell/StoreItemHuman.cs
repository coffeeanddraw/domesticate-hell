// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemHuman : MonoBehaviour
{
    [SerializeField]
    private GameObject storeItem;

    [SerializeField]
    private GameObject insufficientFundsUI;

    [SerializeField]
    private int humanCount;

    [SerializeField]
    private int price;

    [Header("Audio Clip")]
    [SerializeField]
    private AudioClip purchaseSoundEffect;

    private AudioSource insufficientFundsVoice;

    private AudioSource purchaseSound;

    public void Awake()
    {
        insufficientFundsVoice = insufficientFundsUI.GetComponent<AudioSource>();
        purchaseSound = GetComponent<AudioSource>();
        insufficientFundsUI.SetActive(false);
    }

    public void Purchase()
    {
        Debug.Log("Magenta is attempting to purchase human pieces");

        if (GameManager.SoulCount >= price)
        {
            if (GameManager.HasFireKey || GameManager.HasShadowKey || GameManager.HasElectricityKey || GameManager.HasAlchemyKey)
            {
                purchaseSound.PlayOneShot(purchaseSoundEffect);
                GameManager.HumanCount += humanCount;
                GameManager.SoulCount -= price;
            }
        }
        else if (GameManager.SoulCount < price)
        {
            if (insufficientFundsUI != null)
            {
                insufficientFundsUI.SetActive(true);
                playInsufficientFundsVoice();
                Invoke("closeInsufficientFundsUI", 3);
            }
            else if (insufficientFundsUI == null)
            {
                Debug.Log("Insufficient Funds UI is missing");
            }
        }
    }

    void playInsufficientFundsVoice()
    {
        insufficientFundsVoice.Play();
    }

    void closeInsufficientFundsUI()
    {
        insufficientFundsUI.SetActive(false);
    }
}
