// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject currentPanel;

    [SerializeField]
    private GameObject nextPanel; 

    void NextIntro()
    {
        //currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
