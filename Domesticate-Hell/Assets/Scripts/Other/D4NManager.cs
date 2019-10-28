// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;

public class D4NManager : MonoBehaviour
{

    // TODO: Complete D4N Dialogue Box // 

    [SerializeField]
    private GameObject dialogueBoxD4N;

    [SerializeField]
    private Text D4NDialogueText;

    [SerializeField]
    private AnimatorController defaultD4N;

    [SerializeField]
    private AnimatorController notificationD4N;

    private Animator currentD4N;
    private bool completeD4NTutorial = false;
    private bool notification = false;
    private bool D4NDialogueOn = false;

    // static variable for Player_Interaction.cs to access
    private static bool playerInteracting = false;

    public static bool PlayerInteracting
    {
        get { return playerInteracting; }
        set { playerInteracting = value; }
    }

    public bool Notification
    {
        get { return notification; }
        set { notification = value; }
    }

    void Awake()
    {
        currentD4N = GetComponent<Animator>();

        dialogueBoxD4N.SetActive(false);
    }

    void Update()
    {
        CheckInteraction();
    }

    void CheckInteraction()
    {
        // Check if the player is clicking the Interact button AND if the player is interacting with D4N
        if (Input.GetButtonDown("Interact") && playerInteracting && !D4NDialogueOn)
        {
            if (completeD4NTutorial == false)
            {
                D4NTutorial();
                completeD4NTutorial = true;
            }
            else if (completeD4NTutorial == true)
            {
                D4NDefault();
            }
        }
        else if (Input.GetButtonDown("Interact") && playerInteracting && D4NDialogueOn)
        {
            dialogueBoxD4N.SetActive(false);
        }
    }

    // D4N DIALOGUE SETTINGS // 

    void D4NTutorial()
    {
        D4NDialogueText.text = "D4N: Hello, Magenta! I have 666 souls for you.";
        GameManager.SoulCount += 666;
        dialogueBoxD4N.SetActive(true);
        D4NDialogueOn = true;
    }

    void D4NDefault()
    {
        D4NDialogueText.text = "D4N: Hello, Magenta!";
        D4NDialogueOn = true;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is with D4N");
            Debug.Log(completeD4NTutorial);
            if (completeD4NTutorial == false)
            {
                // initiate D4N dialogue 
                notification = true;
                currentD4N.runtimeAnimatorController = notificationD4N;
                Debug.Log("D4N has a notification for the player");
                if (playerInteracting == true)
                {
                    Debug.Log("Player is interacting with D4N");
                }
            }
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is saying bye to D4N");
        }
    }
}
