using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI/Check")]
public class CheckNotReproduction : AINodeCheck
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterAction is AIRabbitAction)
        {
            if (!((Rabbit)aiCharacterAction.animal).isReproduction)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
