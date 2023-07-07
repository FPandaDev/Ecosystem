using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateHunger();
    }

    protected override void LoadComponent()
    {
        hungerCurrent = hungerLevel;
    }
}
