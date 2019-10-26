// Cattatonicat 2019 
// For Domesticate Hell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionMask;

    private void Awake()
    {
        this.selectionMask.SetActive(false);
    }
    
    public void EnableSelectionMask()
    {
        if (selectionMask != null)
        {
            this.selectionMask.SetActive(true);
        }  
    }

    public void DisableSelectionMask()
    {
        if (selectionMask != null)
        {
            this.selectionMask.SetActive(false);
        }
    }
}
