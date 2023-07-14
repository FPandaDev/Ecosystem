using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
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
        aiSensor = GetComponent<AIFoxSensor>();
    }
}
