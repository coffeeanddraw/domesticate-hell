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

    [SerializeField]
    private AudioClip teleporterSoundEffect;

    private Transform destinationLocation;
    private Transform magentaLocation;
    private bool playerInTeleporter = false;

    private AudioSource magentaAudioSource;

    void Awake()
    {
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
                magentaAudioSource.PlayOneShot(teleporterSoundEffect);
                magentaLocation.position = destinationLocation.position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the teleportation area");
            playerInTeleporter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player has left the teleportation area");
            playerInTeleporter = false;
        }
    }
}
