using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterAction : AICharacterControl
{
    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    public virtual void Eat() { }
}
