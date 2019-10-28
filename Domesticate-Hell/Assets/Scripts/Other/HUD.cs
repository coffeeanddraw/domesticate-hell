// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text soulCountText;

    [SerializeField]
    private Text humanCountText;

    void Update()
    {
        PrintSoulAndHumanCount();
    }

    void PrintSoulAndHumanCount()
    {
        soulCountText.text = "Soul: " + GameManager.SoulCount.ToString();
        humanCountText.text = "Human: " + GameManager.HumanCount.ToString();
    }
}
