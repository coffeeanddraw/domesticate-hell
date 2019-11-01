// Angleo & J 
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
    private GameObject pet;

    [Header("Pet Element: Fire / Shadow / Electricity / Alchemy")]
    [SerializeField]
    private string petElement = "";

    [SerializeField]
    private GameObject petStatUI;

    [Header("Pet Eating Sound Effects")]
    [SerializeField]
    private AudioClip magmaCatEating;
    [SerializeField]
    private AudioClip shadowWolfEating;
    [SerializeField]
    private AudioClip brightBunEating;
    [SerializeField]
    private AudioClip mysticMinnowEating;

    [Header("Pet Idle Animations")]
    [SerializeField]
    private RuntimeAnimatorController magmaCatIdleAnimation = null;

    [Header("Pet Eating Animations")]
    [SerializeField]
    private RuntimeAnimatorController magmaCatEatingAnimation = null;

    [SerializeField]
    private Animator petAnimator = null;

    private AudioSource audioSource;

    private int petMaxManna = 999;

    private int petManna = 999;
    private int petChangeInManna;

    private TextMeshProUGUI petStatsTMP;

    private int hungerCounter = 0;
    private int soulCounter = 0;

    private bool playerInRange;

    void Awake()
    {
        pet.SetActive(false);

        petStatsTMP = petStatUI.GetComponent<TextMeshProUGUI>();

        petStatsTMP.SetText("{0}/{1}", petManna, petMaxManna);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateHunger();
        UpdateSoul();
        CheckPetDeath();
        CheckInteraction();
    }

    void UpdateHunger()
    {
        hungerCounter += 1;

        if (hungerCounter == 44)
        {
            petManna -= 1;
            hungerCounter = 0;
        }

        petStatsTMP.SetText("{0}/{1}", petManna, petMaxManna);
    }

    void UpdateSoul()
    {
        soulCounter += 1; 
        if (soulCounter == 22)
        {
            GameManager.SoulCount += 2;
            soulCounter = 0;
        }
    }

    void CheckPetDeath()
    {
        if(this.petManna == 0)
        {
            pet.SetActive(false);
        }
    }

    void CheckInteraction()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if(playerInRange)
            {
                if(GameManager.HumanCount >= 5)
                {
                    GameManager.HumanCount -= 5;
                    petManna += 5;
                    PickEating();
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
