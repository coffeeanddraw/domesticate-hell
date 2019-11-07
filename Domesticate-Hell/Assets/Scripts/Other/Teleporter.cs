// Cattatonicat + Scott 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject destinationTeleporter;

    [SerializeField]
    private GameObject magenta;

    [Header("Sound Effects")]

    [SerializeField]
    private AudioClip teleporterActivatedAudio;

    [SerializeField]
    private AudioClip teleporterUsedAudio;

    [SerializeField]
    private AudioClip teleporterDeactivatedAudio;

    [Header("Animator Controllers")]

    [SerializeField]
    private RuntimeAnimatorController teleporterIdle = null;

    [SerializeField]
    private RuntimeAnimatorController teleporterActivated = null;

    private Animator currentTeleporterAnim;
    private Transform destinationLocation;
    private Transform magentaLocation;
    private Teleporter destinationTeleporterBrain; // Being used for sound fix
    private bool playerInTeleporter = false;

    public bool IsBeingTeleported { private get; set; }  // Being used for sound fix

    private AudioSource magentaAudioSource;

    void Awake()
    {
        currentTeleporterAnim = GetComponent<Animator>();
        destinationLocation = destinationTeleporter.GetComponent<Transform>();
        destinationTeleporterBrain = destinationTeleporter.GetComponent<Teleporter>();
        magentaLocation = magenta.GetComponent<Transform>();
        magentaAudioSource = magenta.GetComponent<AudioSource>();

        IsBeingTeleported = false;

        // Set default teleporter animation to teleporter idle animation
        currentTeleporterAnim.runtimeAnimatorController = teleporterIdle;
    }

    void Update()
    {
        CheckInteraction();
    }

    void CheckInteraction()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (playerInTeleporter)
            {
                destinationTeleporterBrain.IsBeingTeleported = true;
                PlayerUsingTeleporter();
            }
        }
        else
            destinationTeleporterBrain.IsBeingTeleported = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerEnteringTeleporter();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerExitingTeleporter();
        }
    }

    void PlayerEnteringTeleporter()
    {
        Debug.Log("Player has entered a teleporter");

        // IF player is being teleported onto this teleporter THEN don't play the teleporter activation sound
        if (IsBeingTeleported == false)
        {
            magentaAudioSource.PlayOneShot(teleporterActivatedAudio);
        }

        currentTeleporterAnim.runtimeAnimatorController = teleporterActivated;
        playerInTeleporter = true;
    }

    void PlayerExitingTeleporter()
    {
        Debug.Log("Player has left the teleportation area");
        currentTeleporterAnim.runtimeAnimatorController = teleporterIdle;
        playerInTeleporter = false;

        // Example implementation of a SFX that would play when the player steps off the teleporter, but not when they're being teleported off of it
        if (IsBeingTeleported == false)
        {
            magentaAudioSource.PlayOneShot(teleporterDeactivatedAudio);
        }
    }

    void PlayerUsingTeleporter()
    {
        magentaAudioSource.PlayOneShot(teleporterUsedAudio);
        magentaLocation.position = destinationLocation.position;
        IsBeingTeleported = true;
    }
}