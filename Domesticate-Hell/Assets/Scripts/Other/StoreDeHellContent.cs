// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDeHellContent : MonoBehaviour
{
    private string currentMenu = "Home";

    private GameObject[] tickets;
    private GameObject[] humans; 

    private void Awake()
    {
        tickets = GameObject.FindGameObjectsWithTag("StoreItemTickets");
        humans = GameObject.FindGameObjectsWithTag("StoreItemFood");
        ShowItems();
    }

    private void Update()
    {
        if(CattatonicatManager.StoreOnDisplay)
        {
            ShowItems();
        }
    }

    public void ShowItems()
    {
        switch(currentMenu)
        {
            case "Home":
                ShowTickets();
                ShowFood();
                break;
            case "Tickets":
                ShowTickets();
                HideFood();
                break;
            case "Food":
                ShowFood();
                HideTickets();
                break;
        }
    }

    public void SelectHome()
    {
        currentMenu = "Home";
    }

    public void SelectTicketsMenu()
    {
        currentMenu = "Tickets";
    }

    public void SelectFoodMenu()
    {
        currentMenu = "Food";
    }

    private void ShowTickets()
    {
        foreach (GameObject ticket in tickets)
        {
            ticket.SetActive(true);
        }

    }

    private void HideTickets()
    {
        foreach (GameObject ticket in tickets)
        {
            ticket.SetActive(false);
        }
    }

    private void ShowFood()
    {
        foreach (GameObject human in humans)
        {
            human.SetActive(true);
        }
    }

    private void HideFood()
    {
        foreach (GameObject human in humans)
        {
            human.SetActive(false);
        }
    }
}
