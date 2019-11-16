// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/
// https://cattatonicat.tumblr.com/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CattatonicatManager : MonoBehaviour
{
    // Store de Hell Canvas // 
    [SerializeField]
    private GameObject storeDeHell = null;

    // Dialogue Box // 
    [SerializeField]
    private GameObject dialogueBoxCattatonicat = null;

    // Dialogue Box Text // 
    [SerializeField]
    private Text cattatonicatDialogueText = null;

    [Header("Cattatonicat Voice")]
    [SerializeField]
    private AudioClip cattatonicatVoice = null;

    [Header("Store dé Hell Open & Close Sound Effects")]

    [SerializeField]
    private AudioClip storeOpenSound = null;

    [SerializeField]
    private AudioClip storeCloseSound = null;

    private AudioSource storeAudioSource = null;
    
    private bool completeCattatonicatTutorial = false;
    private bool playerInRange = false;
    private bool pendingDialogue = true;
    private bool dialogueOnDisplay = false;

    private static bool storeOnDisplay = false;

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
                if (storeOnDisplay)
                {
                    TurnOffStore();
                    PlayerController.PlayerAllowedToMove = true; 
                }
                else if (!storeOnDisplay)
                {
                    if (dialogueOnDisplay)
                    {
                        TurnOffDialogue();
                        PlayerController.PlayerAllowedToMove = true;
                        dialogueOnDisplay = false;
                    }
                    else if (!dialogueOnDisplay)
                    {
                        if (pendingDialogue)
                        {
                            PlayerController.PlayerAllowedToMove = false;
                            CattatonicatDialogue();
                            dialogueOnDisplay = true;
                        }
                        else if (!pendingDialogue)
                        {
                            TurnOnStore();
                            PlayerController.PlayerAllowedToMove = false;
                        }
                    }
                }
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (playerInRange)
            {
                TurnOffStore();
                PlayerController.PlayerAllowedToMove = true;
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
            storeAudioSource.PlayOneShot(cattatonicatVoice);
            cattatonicatDialogueText.text = "Cattatonicat: Hello, new customer! Please accept this 666 souls as a gesture of good will from AfterLife Wellness.\nI recommend using the souls to help you purchase a ticket to fire habitat.";
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

