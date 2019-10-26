// Cattatonicat 2019 
// For Domesticate Hell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTransition : MonoBehaviour
{
    private GameObject SelectionMask;

    void Awake()
    {
        FindSelectionMask();
    }

    void FindSelectionMask()
    {
        foreach (Transform child in transform)
        {
            // Find the Selection Mask 
            if (child.gameObject.tag == "Selection Mask")
            {
                SelectionMask = child.gameObject;
            }
        }
    }

    public void EnableSelectionMask()
    {
        SelectionMask.SetActive(true);
    }

    public void DisableSelectionMask()
    {
        SelectionMask.SetActive(false);
    }
}
