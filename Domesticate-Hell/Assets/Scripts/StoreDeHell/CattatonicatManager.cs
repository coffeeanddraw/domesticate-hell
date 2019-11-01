// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CattatonicatManager : MonoBehaviour
{
    // Store de Hell Canvas // 
    [SerializeField]
    private GameObject storeDeHell;

    // Dialogue Box // 
    [SerializeField]
    private GameObject dialogueBoxCattatonicat;

    // Dialogue Box Text // 
    [SerializeField]
    private Text cattatonicatDialogueText;

    [Header("Store dé Hell Open & Close Sound Effects")]

    [SerializeField]
    private AudioClip storeOpenSound;

    [SerializeField]
    private AudioClip storeCloseSound;

    private AudioSource storeAudioSource;
    
    private bool completeCattatonicatTutorial = false;
    private bool playerInRange = false;
    private static bool storeOnDisplay = false;

    private static bool pendingDialogue = true; 

    public static bool PendingDialogue
    {
        get { return pendingDialogue; }
        set { pendingDialogue = value; }
    }

    public static bool StoreOnDisplay
    {
        get { return storeOnDisplay; }
    }

    void Awake()
    {
        storeDeHell.SetActive(false);
        dialogueBoxCattatonicat.SetActive(false);
        storeAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckInteraction();
    }

    void CheckInteraction()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if(playerInRange)
            {
                if(pendingDialogue == true)
                {
                    CattatonicatDialogue();
                    Debug.Log("Calling 'CattatonicatDialogue()'");
                    Invoke("TurnOffDialogue", 5);
                    pendingDialogue = false; 
                }
                else if (pendingDialogue == false)
                {
                    TurnOffDialogue();

                    if (storeOnDisplay == false)
                    {
                        TurnOnStore();
                    }
                    else if (storeOnDisplay == true)
                    {
                        TurnOffStore();
                    }
                }
            }
        }
    }

    // Detect Player Enter & Exit State // 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Magenta is at the store");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Magenta is leaving the store");
        }
    }

    void CattatonicatDialogue()
    {
        if (!completeCattatonicatTutorial)
        {
            // Tutorial Dialogue // 
            Debug.Log("Initiating Cattatonicat tutorial...");
            cattatonicatDialogueText.text = "Cattatonicat: Hello, Magenta! I have 666 souls for you!";
            dialogueBoxCattatonicat.SetActive(true);
            GameManager.SoulCount += 666;
            Debug.Log("+ 666 souls");
            completeCattatonicatTutorial = true;
            pendingDialogue = false;
        }
        else if (completeCattatonicatTutorial)
        {
            // Regular Dialogue // 
        }
    }

    void TurnOffDialogue()
    {
        dialogueBoxCattatonicat.SetActive(false);
    }

    void TurnOnStore()
    {
        Debug.Log("Attempting to open store de Hell");
        storeAudioSource.PlayOneShot(storeOpenSound);
        storeDeHell.SetActive(true);
        storeOnDisplay = true;
    }

    void TurnOffStore()
    {
        Debug.Log("Attempting to close store de Hell");
        storeAudioSource.PlayOneShot(storeCloseSound);
        storeDeHell.SetActive(false);
        storeOnDisplay = false;
    }
}

