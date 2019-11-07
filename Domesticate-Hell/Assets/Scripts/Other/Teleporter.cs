// Cattatonicat 2019 
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

    [Header("Animator Controllers")]

    [SerializeField]
    private RuntimeAnimatorController teleporterIdle = null;

    [SerializeField]
    private RuntimeAnimatorController teleporterActivated = null;

    private Animator currentTeleporterAnim;
    private Transform destinationLocation;
    private Transform magentaLocation;
    private bool playerInTeleporter = false;

    private AudioSource magentaAudioSource;

    void Awake()
    {
        currentTeleporterAnim = GetComponent<Animator>();
        destinationLocation = destinationTeleporter.GetComponent<Transform>();
        magentaLocation = magenta.GetComponent<Transform>();
        magentaAudioSource = magenta.GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckInteraction();
    }

    void CheckInteraction()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if(playerInTeleporter)
            {
                PlayerUsingTeleporter();
            }
        }
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
        magentaAudioSource.PlayOneShot(teleporterActivatedAudio);
        currentTeleporterAnim.runtimeAnimatorController = teleporterActivated;
        playerInTeleporter = true;
    }

    void PlayerExitingTeleporter()
    {
        Debug.Log("Player has left the teleportation area");
        currentTeleporterAnim.runtimeAnimatorController = teleporterIdle;
        playerInTeleporter = false;
    }

    void PlayerUsingTeleporter()
    {
        magentaAudioSource.PlayOneShot(teleporterUsedAudio);
        magentaLocation.position = destinationLocation.position;
    }
}
