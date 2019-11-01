// Angleo & J 
// Domesticate Hell 2019

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [Header("Pet Element: Fire / Shadow / Electricity / Alchemy")]
    [SerializeField]
    private string element = ""; 

    [SerializeField]
    private int petMaxManna;

    private int petManna;
    private int petChangeInManna;

    //public GameObject pet_gameObject;

    //void Start()
    //{
    //    this.pet_hunger = 5;
    //    this.pet_health = 100;
    //    this.pet_experience = 0;
    //    this.pet_level = 1;
    //}

    void Update()
    {

        //timePerHunger += Time.deltaTime;
        //timeGenerateItem += Time.deltaTime;

        //if (timePerHunger > 10)
        //{
        //    damagePerTime();
        //    resetTimePerHunger();
        //}

        //if (timeGenerateItem > 10)
        //{
        //    generateItem();
        //    resetTimeGenerateItem();
        //}

        //checkPetHealth();
        //checkPetLevel();

    }

    //private void resetTimeGenerateItem()
    //{
    //    this.timeGenerateItem = 0f;
    //}

    //private void checkPetLevel()
    //{
    //    if (this.pet_experience == 100)
    //    {
    //        this.pet_level += 1;
    //        this.pet_experience = 0;
    //    }
    //}

    //private void checkPetHealth()
    //{
    //    if (this.pet_health <= 0)
    //    {
    //        this.gameObject.SetActive(false);
    //    }
    //}

    //void resetTimePerHunger()
    //{
    //    this.timePerHunger = 0f;
    //}

    //void damagePerTime()
    //{
    //    this.petManna = this.petMaxManna - this.petChangeInManna;
    //}

    //public void giveFoodToPet(GameObject food)
    //{
    //    int health = food.GetComponent<InteractionObject>().health;
    //    int xp = food.GetComponent<InteractionObject>().xp;

    //    this.pet_health += health;
    //    this.pet_experience += xp;
    //}

    //void generateItem()
    //{
    //    Vector3 x = new Vector3(pet_gameObject.transform.position.x - 1, pet_gameObject.transform.position.y, pet_gameObject.transform.position.z - 1);

    //    Instantiate(generateItemPrefab, x, Quaternion.identity);
    //}
}
