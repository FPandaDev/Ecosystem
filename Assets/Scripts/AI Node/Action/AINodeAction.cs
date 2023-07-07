using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINodeAction : AINode
{
    protected AICharacterAction aiCharacterAction;

    public override void OnStart()
    {
        base.OnStart();
        LoadComponent();     
    }

    public override void LoadComponent()
    {
        aiCharacterAction = GetComponent<AICharacterAction>();
        aiCharacterControl = GetComponent<AICharacterControl>();      
    }
}
