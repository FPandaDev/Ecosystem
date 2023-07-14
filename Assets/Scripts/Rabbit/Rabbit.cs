using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rabbit : Animal
{
    public TextMeshProUGUI stateText; 

    protected override void LoadComponent()
    {
        base.LoadComponent();   
        aiSensor = GetComponent<AIRabbitSensor>();
    }

    public void IsBeingEaten()
    {
        Destroy(gameObject);
    }
}
