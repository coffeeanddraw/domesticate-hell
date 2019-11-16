// Angelo & J 
// Domesticate Hell 2019

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pet : MonoBehaviour
{
    [SerializeField]
    private GameObject pet = null;

    [Header("Pet Element: Fire / Shadow / Electricity / Alchemy")]
    [SerializeField]
    private string petElement = "";

    [SerializeField]
    private GameObject petStatUI = null;

    [Header("Pet Eating Sound Effects")]
    [SerializeField]
    private AudioClip magmaCatEating = null;
    [SerializeField]
    private AudioClip shadowWolfEating = null;
    [SerializeField]
    private AudioClip brightBunEating = null;
    [SerializeField]
    private AudioClip mysticMinnowEating = null;

    [Header("Pet Idle Animations")]
    [SerializeField]
    private RuntimeAnimatorController magmaCatIdleAnimation = null;

    [Header("Pet Eating Animations")]
    [SerializeField]
    private RuntimeAnimatorController magmaCatEatingAnimation = null;

    [SerializeField]
    private Animator petAnimator = null;

    private AudioSource audioSource = null;

    private int petMaxManna = 88;

    private int petManna = 88;
    private int petChangeInManna = 0;

    private TextMeshProUGUI petStatsTMP = null;

    private int hungerCounter = 0;
    private int soulCounter = 0;

    private bool playerInRange = false;

    void Awake()
    {
        pet.SetActive(false);

        petStatsTMP = petStatUI.GetComponent<TextMeshProUGUI>();

        petStatsTMP.SetText("{0}/{1}", petManna, petMaxManna);

        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (petManna != 0)
        {
            UpdateHunger();
            UpdateSoul();
        } 
    }

    void Update()
    {
        //CheckPetDeath();
        CheckInteraction();
    }

    void UpdateHunger()
    {
        hungerCounter += 1;

        if (hungerCounter == 22)
        {
            petManna -= 1;
            hungerCounter = 0; 
        }
        petStatsTMP.SetText("{0}/{1}", petManna, petMaxManna);
    }

    void UpdateSoul()
    {
        soulCounter += 1; 
        if (soulCounter == 2)
        {
            GameManager.SoulCount += 2;
            soulCounter = 0;
            
        }
    }

    // Pet death state has been taken out for Logan Theatre Playtesting Party
    //void CheckPetDeath()
    //{
    //    if(this.petManna == 0)
    //    {
    //        pet.SetActive(false);
    //    }
    //}

    void CheckInteraction()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if(playerInRange)
            {
                if(GameManager.HumanCount >= 5)
                {
                    if(petManna != 88)
                    {
                        GameManager.HumanCount -= 5;
                        petManna += 5;
                        PickEating();
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Magenta is with a pet");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; 
        }
    }

    void PickEating()
    {
        switch(petElement)
        {
            case "Fire":
                audioSource.PlayOneShot(magmaCatEating);
                petAnimator.runtimeAnimatorController = magmaCatEatingAnimation;
                petAnimator.runtimeAnimatorController = magmaCatIdleAnimation;
                break;
            case "Shadow":
                audioSource.PlayOneShot(shadowWolfEating);
                break;
            case "Electricity":
                audioSource.PlayOneShot(brightBunEating);
                break;
            case "Alchemy":
                audioSource.PlayOneShot(mysticMinnowEating);
                break;
        }
    }
}
