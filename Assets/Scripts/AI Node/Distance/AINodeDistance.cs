using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINodeDistance : AINode
{
    public override void OnStart()
    {
        base.OnStart();
        LoadComponent();
    }

    public override void LoadComponent()
    {
        aiCharacterControl = GetComponent<AICharacterControl>();
    }
}