using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node")]
public class AINode : Action
{
    protected AICharacterControl aiCharacterControl;

    public virtual void LoadComponent() { }
}