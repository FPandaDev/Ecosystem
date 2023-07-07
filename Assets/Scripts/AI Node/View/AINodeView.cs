using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINodeView : AINode
{
    public override void OnStart()
    {
        base.OnStart();
        LoadComponent();
    }

    public override void LoadComponent()
    {
        aiCharacterControl = GetComponent<AICharacterVehicle>();
    }
}