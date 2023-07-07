using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { WANDER, EATING, REPRODUCTION, SEARCHFOOD, SEARCHMATE, EVADE }

public class Animal : MonoBehaviour
{
    [Header("ATTRIBUTES")]
    [SerializeField] public State stateCurrent;

    [Header("HUNGER")]
    [SerializeField] protected float hungerLevel = 100f;
    [SerializeField] protected float hungerLevelMin = 30f;
    [SerializeField] protected float hungerLevelMax = 85f;

    public float hungerCurrent;

    public bool hasHunger;
    public bool hasHungeHigh;

    [Header("IDLE")]
    [SerializeField] protected float timeToPregmant = 5f;

    protected virtual void LoadComponent() { }

    protected virtual void UpdateHunger()
    {
        if (stateCurrent == State.EATING)
        {
            hungerCurrent += Time.deltaTime;

            if (hungerCurrent >= hungerLevel)
            {
                hasHunger = false;
            }
        }
        else
        {
            hungerCurrent -= Time.deltaTime;

            hasHunger = hungerCurrent <= hungerLevelMax;              
            hasHungeHigh = hungerCurrent <= hungerLevelMin;            
        }
    }

    public void ChangeState(State newState)
    {
        if (newState == stateCurrent) { return; }

        stateCurrent = newState;
    }
}
