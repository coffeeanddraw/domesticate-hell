using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject yourFutureIsProtectedCanvas;

    [SerializeField]
    private GameObject credits;

    private bool creditsOpen = false;

    void Awake()
    {
        yourFutureIsProtectedCanvas.SetActive(true);
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
