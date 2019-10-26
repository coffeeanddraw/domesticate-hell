using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D4N : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is with D4N");
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
