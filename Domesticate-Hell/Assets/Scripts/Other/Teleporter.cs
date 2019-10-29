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

    private Transform destinationLocation;
    private Transform magentaLocation;
    private bool playerInTeleporter = false;

    void Awake()
    {
        destinationLocation = destinationTeleporter.GetComponent<Transform>();
        magentaLocation = magenta.GetComponent<Transform>();
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
