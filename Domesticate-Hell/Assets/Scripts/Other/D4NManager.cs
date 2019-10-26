using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class D4NManager : MonoBehaviour
{
    [SerializeField]
    private Animator currentD4N; 

    [SerializeField]
    private AnimatorController defaultD4N;

    [SerializeField]
    private AnimatorController notificationD4N;

    private bool completeD4NTutorial = false;
    private bool notification = false;
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
        CheckCompleteD4NTutorialState();
        currentD4N = GetComponent<Animator>();
    }

    void CheckCompleteD4NTutorialState()
    {
        if (GameManager.CompleteD4NIntro == false)
        {
            completeD4NTutorial = false; 
        }
        else if(GameManager.CompleteD4NIntro == true)
        {
            completeD4NTutorial = true; 
        }
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
            Debug.Log(completeD4NTutorial);
        }
    }
}
