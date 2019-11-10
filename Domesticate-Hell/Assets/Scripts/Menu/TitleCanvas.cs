using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvas : MonoBehaviour
{

    [SerializeField]
    private GameObject credits;

    private bool creditsOpen = false;

    void Awake()
    {
        credits.SetActive(false);
    }
    
    public void ToggleCredits()
    {
        if (!creditsOpen)
        {
            credits.SetActive(true);
            creditsOpen = true;
        }
        else if (creditsOpen)
        {
            credits.SetActive(false);
            creditsOpen = false;
        }
       
    }
}
