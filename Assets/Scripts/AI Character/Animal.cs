using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AGE { CHILDREN, YOUNG }
public enum STATE { WANDER, EATING, REPRODUCTION, SEARCHFOOD, SEARCHMATE, EVADE }

public class Animal : MonoBehaviour
{
    [Header("ATTRIBUTES")]
    [SerializeField] public STATE stateCurrent;
    [SerializeField] public AGE age;
    [SerializeField] protected float ageMin = 20f;
    [SerializeField] protected float ageMax = 60f;

    public float ageCurrent;

    [Header("HUNGER")]
    [SerializeField] protected float hungerLevel = 100f;
    [SerializeField] protected float hungerLevelMin = 30f;
    [SerializeField] protected float hungerLevelMax = 85f;

    public float hungerCurrent;

    public bool hasHunger;
    public bool hasHungeHigh;

    [Header("IDLE")]
    [SerializeField] protected float ToPregmant = 5f;

    public float timeToPregmant;

    public bool isReproduction;

    protected AISensor aiSensor;

    protected virtual void LoadComponent()
    {
        hungerCurrent = hungerLevel;
        ageCurrent = 0f;
        hasHunger = false;
        hasHungeHigh = false;
    }

    protected virtual void UpdateAge()
    {
        ageCurrent += Time.deltaTime;

        if (ageCurrent < ageMin)
        {
            age = AGE.CHILDREN;
            transform.localScale = Vector3.one * 0.5f;
        }
        else if (ageCurrent >= ageMin && ageCurrent < ageMax)
        {
            transform.localScale = Vector3.one;
            age = AGE.YOUNG;
        }
        else if (ageCurrent >= ageMax)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void UpdateHungerLevel()
    {
        if (stateCurrent != STATE.EATING)
        {
            hungerCurrent -= Time.deltaTime;

            hasHunger = hungerCurrent <= hungerLevelMax;              
            hasHungeHigh = hungerCurrent <= hungerLevelMin;
            
            if (hungerCurrent <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public virtual void UpdateHunger()
    {
        ChangeState(STATE.EATING);

        hungerCurrent += Time.deltaTime;

        if (hungerCurrent >= hungerLevel)
        {
            hasHunger = false;
        }
    }

    public virtual void UpdateReprodution()
    {

    }

    public virtual void ChangeState(STATE newState)
    {
        if (newState == stateCurrent) { return; }

        stateCurrent = newState;

        switch (newState)
        {
            case STATE.EATING:
                break;

            case STATE.REPRODUCTION:
                isReproduction = true;
                timeToPregmant = 0f;
                break;
        }
    }
}
