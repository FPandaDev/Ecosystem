using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI/Check")]
public class CheckNotHunger : AINodeCheck
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterAction is AIRabbitAction)
        {
            if (!((Rabbit)aiCharacterAction.animal).hasHunger)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
