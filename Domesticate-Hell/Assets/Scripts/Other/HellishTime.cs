using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI; 

public class HellishTime : MonoBehaviour
{
    [SerializeField]
    private Text clockText;

    [SerializeField]
    private Text dayText;

    private const float secondsPerDay = 120f;

    private int days = 0;
    private int hours = 20;
    private int mintues = 0;
    private int seconds = 0;

    // Update is called once per frame
    void Update()
    {
        while(true)
        {
            seconds += (int)Math.Round(Time.deltaTime);
            clockText.text = seconds.ToString();
        }
    }
}
