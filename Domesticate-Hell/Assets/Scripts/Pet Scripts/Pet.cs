using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    private enum pet_Type {Shadow, Fire, Electricity, Alchemy};
    public int pet_hunger;
    public int pet_health;
    public int pet_experience;
    public int pet_level;

    float timePerHunger;
    float timeGenerateItem;


    public GameObject generateItemPrefab;

    void Start()
    {
        this.pet_hunger = 5;
        this.pet_health = 100;
        this.pet_experience = 0;
        this.pet_level = 1;
    }

    void Update()
    {
        timePerHunger += Time.deltaTime;
        timeGenerateItem += Time.deltaTime;

        if (timePerHunger > 10)
        {
            damagePerTime();
            resetTimePerHunger();
        }

        if (timeGenerateItem > 10)
        {
            generateItem();
            resetTimeGenerateItem();
        }

        checkPetHealth();
        checkPetLevel();

    }

    private void resetTimeGenerateItem()
    {
        this.timeGenerateItem = 0f;
    }

    private void checkPetLevel()
    {
        if (this.pet_experience == 100)
        {
            this.pet_level += 1;
            this.pet_experience = 0;
        }
    }

    private void checkPetHealth()
    {
        if (this.pet_health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void resetTimePerHunger()
    {
        this.timePerHunger = 0f;
    }

    void damagePerTime()
    {
        this.pet_health = this.pet_health - this.pet_hunger;
    }

    public void giveFoodToPet(GameObject food)
    {
        int health = food.GetComponent<InteractionObject>().health;
        int xp = food.GetComponent<InteractionObject>().xp;

        this.pet_health += health;
        this.pet_experience += xp;
    }

    void generateItem()
    {
        Vector3 x = new Vector3(this.gameObject.transform.localPosition.x - 1, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);

        Instantiate(generateItemPrefab, x, Quaternion.identity);
    }
}
