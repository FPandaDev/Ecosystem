using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{  
    [Header("TO IDLE")]  
    public bool isEating;
    public bool isMate;
    [SerializeField] protected Material matOld;

    protected AISensorRabbit sensor;
    public MeshRenderer material;

    public Rabbit mate;

    

    public virtual void LoadComponent()
    {
        sensor = GetComponent<AISensorRabbit>();

        ageTime = 0f;
        healthCurrent = healtMax;
        hungerLevel = hunger;
        thirstLevel = thirst;
        staminaCurrent = staminaMax;
    }

    public virtual void InReproduction() { }

    protected void UpdateHungerTime()
    {
        if (isEating)
        {
            hungerLevel += Time.deltaTime;

            if (hungerLevel >= hunger)
                isEating = false;
        }                 
        else
        {
            hungerLevel -= Time.deltaTime;
        }          
   
        hungerLevel = Mathf.Clamp(hungerLevel, 0, hunger);
        sliderHungry.value = hungerLevel / hunger;
    }

    protected void UpdateAgeTime()
    {
        ageTime += Time.deltaTime;

        if (ageTime <= 20)
            age = Age.CHILD;
        else if (ageTime > 20 && ageTime <= 50)
            age = Age.YOUNG;
        else if (ageTime > 50)
            age = Age.OLD;

        switch (age)
        {
            case Age.CHILD:
                transform.localScale = Vector3.one / 2f;
                break;

            case Age.YOUNG:
                transform.localScale = Vector3.one;
                break;

            case Age.OLD:
                material.material = matOld;
                break;
        }
    }

    protected void UpdateState()
    {
        if (isEating) { state = State.EATING; }

        else if (isMate) { state = State.REPRODUCTION; }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Food food = other.gameObject.GetComponent<Food>();
            if (food != null)
            {
                food.rabbits.Add(this);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Food food = other.gameObject.GetComponent<Food>();
            
            if (food != null)
            {
                isEating = true;
                food.IsBeingEaten();
            }
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Food food = other.gameObject.GetComponent<Food>();
            food.rabbits.Remove(this);
            isEating = false;
        }

        if (other.gameObject.CompareTag("Rabbit"))
        {
            timerP = 0f;
            mate = null;
            isMate = false;
        }
    }
}
