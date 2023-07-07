using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMale : Rabbit
{
    private void Update()
    {
        UpdateHungerLevel();
    }

    public override void UpdateReprodution()
    {
        ChangeState(State.REPRODUCTION);

        if (stateCurrent == State.REPRODUCTION)
        {
            timeToPregmant += Time.deltaTime;          

            if (timeToPregmant > ToPregmant)
            {
                isReproduction = false;
            }
        }
    }

    public override void ChangeState(State newState)
    {
        if (newState == stateCurrent) { return; }

        stateCurrent = newState;

        if (newState != State.REPRODUCTION)
        {
            timeToPregmant = 0f;
            isReproduction = false;
        }

        switch (newState)
        {
            case State.EATING:
                break;

            case State.REPRODUCTION:
                ((AIRabbitSensor)aiSensor).mateTarget.GetComponent<RabbitFemale>().SetViewMate(this);
                isReproduction = true;
                timeToPregmant = 0f;
                break;
        }
    }
}