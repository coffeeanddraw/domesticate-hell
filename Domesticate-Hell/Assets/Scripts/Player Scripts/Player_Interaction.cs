using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField] private GameObject currentObject;

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && currentObject)
        {
            currentObject.SendMessage("doInteraction");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("other.name");
            currentObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            currentObject = null;
        }
    }

}
