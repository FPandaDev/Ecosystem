using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRabbitAction : AICharacterAction
{
    private void Start()
    {
        this.LoadComponent();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    public override void Eat()
    {
        //animal.ChangeState(State.EATING);
        agent.isStopped = true;
        animal.UpdateHunger();

        ((AIRabbitSensor)sensor).foodTarget.GetComponent<Food>().IsBeingEaten();      
    }

    public override void Reproduction()
    {
        //animal.ChangeState(State.REPRODUCTION);
        agent.isStopped = true;
        animal.UpdateReprodution();
    }
}