using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMale : Rabbit
{
    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateAge();
        UpdateHungerLevel();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    public override void UpdateReprodution()
    {
        ChangeState(STATE.REPRODUCTION);

        if (stateCurrent == STATE.REPRODUCTION)
        {
            timeToPregmant += Time.deltaTime;          

            if (timeToPregmant > ToPregmant)
            {
                isReproduction = false;
            }
        }
    }

    public override void ChangeState(STATE newState)
    {
        if (newState == stateCurrent) { return; }

        stateCurrent = newState;

        if (newState != STATE.REPRODUCTION)
        {
            timeToPregmant = 0f;
            isReproduction = false;
        }

        switch (newState)
        {
            case STATE.EATING:
                break;

            case STATE.REPRODUCTION:
                ((AIRabbitSensor)aiSensor).mateTarget.GetComponent<RabbitFemale>().SetViewMate(this);
                isReproduction = true;
                timeToPregmant = 0f;
                break;
        }
    }
}