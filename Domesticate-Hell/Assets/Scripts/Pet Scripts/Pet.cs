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


    void Start()
    {
        this.pet_hunger = 5;
        this.pet_health = 100;
        this.pet_experience = 0;
        this.pet_level = 1;
}

    void Update()
    {
        Debug.Log(timePerHunger);
        timePerHunger += Time.deltaTime;

        if(timePerHunger > 10)
        {
            damagePerTime();
            resetTimePerHunger();
        }

        checkPetHealth();

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

    void giveFoodToPet(InteractionObject food)
    {
        this.pet_health += food.health;
        this.pet_experience += food.xp;
    }
}
