// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D4NManager : MonoBehaviour
{
    [Header("D4N dialogue UI")]

    [SerializeField]
    private GameObject dialogueBoxD4N;

    [SerializeField]
    private Text D4NDialogueText;

    [Header("D4N Soune Effect")]

    [SerializeField]
    private AudioClip voiceD4N;

    private AudioSource audioSourceD4N;
    private Animator animatorD4N;
    private bool completeD4NTutorial = false;
    private bool dialogueOnD4N = false;
    private bool playerInteracting = false;
    private bool playerInRange = false;

    void Awake()
    {
        animatorD4N = GetComponent<Animator>();
        audioSourceD4N = GetComponent<AudioSource>();

        dialogueBoxD4N.SetActive(false);
    }

    void Update()
    {
        CheckInteraction();
    }

    void CheckInteraction()
    {
        if (Input.GetButtonDown("Interact") && playerInRange && !playerInteracting)
        {
            playerInteracting = true;
            animatorD4N.SetBool("PlayerInteracting", true);
            PlayerController.PlayerAllowedToMove = false;

            if (!dialogueOnD4N)
            {
                if (!completeD4NTutorial)
                {
                    D4NDialogueText.text = "D4N: Hello, Magenta! I have 666 souls for you.";
                    GameManager.SoulCount += 666;
                    dialogueBoxD4N.SetActive(true);
                    audioSourceD4N.PlayOneShot(voiceD4N);
                    dialogueOnD4N = true;
                    completeD4NTutorial = true;
                    
                }
                else if (completeD4NTutorial)
                {
                    animatorD4N.SetBool("D4NHeartReaction", true);
                    //D4NDialogueText.text = "D4N: Hello, Magenta!";
                    //dialogueBoxD4N.SetActive(true);
                    //dialogueOnD4N = true;
                }
            }
        }
        else if (Input.GetButtonDown("Interact") && playerInRange && playerInteracting)
        {
            animatorD4N.SetBool("PlayerInteracting", false);
            playerInteracting = false;
            PlayerController.PlayerAllowedToMove = true;
            if (dialogueOnD4N)
            {
                dialogueBoxD4N.SetActive(false);
                dialogueOnD4N = false;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            animatorD4N.SetBool("PlayerNearby", true);
            Debug.Log("Player is with D4N");
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            animatorD4N.SetBool("PlayerNearby", false);
            animatorD4N.SetBool("PlayerInteracting", false);
            animatorD4N.SetBool("D4NHeartReaction", false);
            Debug.Log("Player is saying bye to D4N");
        }
    }
}
