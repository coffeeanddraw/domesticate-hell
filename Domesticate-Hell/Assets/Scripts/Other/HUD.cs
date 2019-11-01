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

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private GameObject time;

    void Update()
    {
        PrintHUD();
        time.SetActive(true);
    }

    void PrintHUD()
    { 
        soulCountText.text = "Soul: " + GameManager.SoulCount.ToString();
        humanCountText.text = "Human: " + GameManager.HumanCount.ToString();
        timeText.text = HellishTime.FormatedTime;
    }
}
