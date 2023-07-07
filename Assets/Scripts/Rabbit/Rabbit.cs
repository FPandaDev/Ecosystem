using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    private void Start()
    {
        LoadComponent();
    }

    protected override void LoadComponent()
    {
        hungerCurrent = hungerLevel;
        aiSensor = GetComponent<AIRabbitSensor>();
    }
}
