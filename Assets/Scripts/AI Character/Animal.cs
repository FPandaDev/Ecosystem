using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GENDER { MALE, FEMALE }
public enum State { WANDER, EATING, REPRODUCTION, SEARCHFOOD, SEARCHMATE, EVADE }

public class Animal : MonoBehaviour
{
    [Header("ATTRIBUTES")]
    [SerializeField] public State stateCurrent;
    [SerializeField] public GENDER gender;

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

    protected virtual void LoadComponent() { }

    protected virtual void UpdateHungerLevel()
    {
        if (stateCurrent != State.EATING)
        {
            hungerCurrent -= Time.deltaTime;

            hasHunger = hungerCurrent <= hungerLevelMax;              
            hasHungeHigh = hungerCurrent <= hungerLevelMin;            
        }
    }
    public virtual void UpdateHunger()
    {
        ChangeState(State.EATING);

        hungerCurrent += Time.deltaTime;

        if (hungerCurrent >= hungerLevel)
        {
            hasHunger = false;
        }
    }

    public virtual void UpdateReprodution()
    {

    }

    public virtual void ChangeState(State newState)
    {
        if (newState == stateCurrent) { return; }

        stateCurrent = newState;

        switch (newState)
        {
            case State.EATING:
                break;

            case State.REPRODUCTION:
                isReproduction = true;
                timeToPregmant = 0f;
                break;
        }
    }
}
