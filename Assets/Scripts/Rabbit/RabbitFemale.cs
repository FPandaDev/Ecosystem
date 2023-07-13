using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RabbitFemale : Rabbit
{
    [Header("REPRODUCTION")]
    [SerializeField] private float heatTime = 100f;
    [SerializeField] private float gestationTime = 100f;

    public bool inHeat = false;
    public bool isPregnant = false;

    public float heatCurrent;
    public float gestationCurrent;

    private RabbitMale target;

    private void Update()
    {
        UpdateHungerLevel();
        UpdateHeat();
        UpdatePregmant();
    }

    private void UpdateHeat()
    {
        if (!inHeat && !isPregnant)
        {
            heatCurrent += Time.deltaTime;

            if (heatCurrent >= heatTime)
            {
                heatCurrent = 0f;
                inHeat = true;
            }        
            //heatCurrent = Mathf.Clamp(heatCurrent, 0f, heatTime);
            //inHeat = heatCurrent >= heatTime;
        }   
    }

    private void UpdatePregmant()
    {
        if (isPregnant)
        {
            gestationCurrent += Time.deltaTime;

            if (gestationCurrent >= gestationTime)
            {
                // Función para crear conejos

                gestationCurrent = 0f;
                inHeat = false;
                isPregnant = false;
            }
        }
    }

    public override void UpdateReprodution()
    {       
        if (stateCurrent == State.REPRODUCTION)
        {
            timeToPregmant += Time.deltaTime;
            RotateMate();

            if (timeToPregmant >= ToPregmant)
            {
                isPregnant = true;
                isReproduction = false;
            }

            if (!target.isReproduction)
            {
                isReproduction = false;
            }
        }
    }

    public void SetViewMate(RabbitMale _target)
    {
        target = _target;
        ChangeState(State.REPRODUCTION);      
    }

    private void RotateMate()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
    }

    public override void ChangeState(State newState)
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