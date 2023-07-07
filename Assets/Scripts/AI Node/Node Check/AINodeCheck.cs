using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI")]
public class AINodeCheck : AINode
{
    protected AICharacterAction aiCharacterAction;

    public override void OnStart()
    {
        base.OnStart();
        LoadComponent();
    }

    public override void LoadComponent()
    {
        aiCharacterControl = GetComponent<AICharacterControl>();
        aiCharacterAction = GetComponent<AICharacterAction>();
    }
}
