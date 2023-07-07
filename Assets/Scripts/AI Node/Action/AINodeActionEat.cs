using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("My AI/Action")]
public class AINodeActionEat : AINodeAction
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterAction is AIRabbitAction)
        {
            if (((AISensorRabbit)aiCharacterControl._sensor).foodTarget != null)
            {
                ((AIRabbitAction)aiCharacterAction).Eat();
                return TaskStatus.Running;
            }
        }
        return TaskStatus.Failure;
    }
}
