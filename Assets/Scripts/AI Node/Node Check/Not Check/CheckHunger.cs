using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Check")]
public class CheckHunger : AINodeCheck
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterAction is AIRabbitAction)
        {
            if (((Rabbit)aiCharacterAction.animal).hasHunger)
            {
                return TaskStatus.Success;
            }
        }
        else if (aiCharacterAction is AIFoxAction)
        {
            if (((Fox)aiCharacterAction.animal).hasHunger)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
