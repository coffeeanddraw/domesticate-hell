using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HellishTime : MonoBehaviour
{
    [SerializeField]
    private Text clockText;

    private const float secondsPerDay = 120f;

    private int days = 0;
    private int hours = 20;
    private int minutes = 0;
    private int seconds = 0;
    private float calculateSeconds = 0; 

    // Update is called once per frame
    void Update()
    {
        CalculateTime();

        PrintTime();
    }

    private void CalculateTime()
    {
        calculateSeconds += 1; 

        // Change this statement to change how fast the time goes in game
        if (calculateSeconds == 1)
        {
            seconds += 1;
            calculateSeconds = 0;
        }

        if (seconds == 60)
        {
            minutes += 1;
            seconds = 0; 
        }

        if (minutes == 60)
        {
            hours += 1;
            minutes = 0;
        }

        if (hours == 24)
        {
            days += 1;
            hours = 0; 
        }
    }

    private void PrintTime()
    {
        string dag = days.ToString(); // day in dutch
        string uur = " "; // hours in dutch
        string notulen = " "; // minutes in dutch
        string amOrPm = "AM";
         

        if (hours < 12)
        {
            if (hours == 0)
            {
                uur = "12";
            } else
            {
                uur = hours.ToString();
                amOrPm = "AM"; 
            }
          
        } else if (hours >= 12)
        {
            amOrPm = "PM";
        }

        if (minutes <10)
        {
            notulen = "0" + minutes.ToString();
        } else if (minutes >=10)
        {
            notulen = minutes.ToString();
        }

        switch (hours)
        {
            case 13:
                uur = "1"; 
                break;
            case 14:
                uur = "2";
                break;
            case 15:
                uur = "3";
                break;
            case 16:
                uur = "4";
                break;
            case 17:
                uur = "5";
                break;
            case 18:
                uur = "6";
                break;
            case 19:
                uur = "7";
                break;
            case 20:
                uur = "8";
                break;
            case 21:
                uur = "9";
                break;
            case 22:
                uur = "10";
                break;
            case 23:
                uur = "11";
                break;
        } 

        // Print current time to canvas
        clockText.text = "Day: " + days.ToString() + "    " + uur + ":" + notulen + " " + amOrPm;
    }
}   
