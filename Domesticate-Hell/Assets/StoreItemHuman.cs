using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemHuman : MonoBehaviour
{
    [SerializeField]
    private GameObject storeItem;

    [SerializeField]
    private GameObject purchaseButton;

    [SerializeField]
    private GameObject insufficientFundsUI;

    [SerializeField]
    private int humanCount;

    [SerializeField]
    private int price;

    private AudioSource insufficientFundsVoice;

    public void Awake()
    {

        insufficientFundsVoice = insufficientFundsUI.GetComponent<AudioSource>();
        this.purchaseButton.SetActive(true);
        insufficientFundsUI.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Purchase()
    {
        Debug.Log("Magenta is attempting to purchase human pieces");

        if (GameManager.SoulCount >= price)
        {
            GameManager.HumanCount += humanCount;
            GameManager.SoulCount -= price;
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
