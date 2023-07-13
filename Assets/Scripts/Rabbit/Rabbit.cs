using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    

    protected override void LoadComponent()
    {
        base.LoadComponent();   
        aiSensor = GetComponent<AIRabbitSensor>();
    }
}
