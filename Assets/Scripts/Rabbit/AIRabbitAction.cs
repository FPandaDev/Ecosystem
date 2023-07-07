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
        animal.ChangeState(State.EATING);
        ((AIRabbitSensor)sensor).foodTarget.GetComponent<Food>().IsBeingEaten();
    }
}
