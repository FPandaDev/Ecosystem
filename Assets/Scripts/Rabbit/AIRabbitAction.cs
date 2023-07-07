using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRabbitAction : AICharacterAction
{
    private AISensorRabbit sensor;

    private void Start()
    {
        this.LoadComponent();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
        sensor = _sensor as AISensorRabbit;
    }

    public override void Eat()
    {
        sensor.foodTarget.GetComponent<Food>().IsBeingEaten();
    }
}
