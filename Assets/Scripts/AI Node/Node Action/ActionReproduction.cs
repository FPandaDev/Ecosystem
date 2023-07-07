using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI/Action")]
public class ActionReproduction : AINodeAction
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterAction is AIRabbitAction)
        {
            //if (((AIRabbitSensor)aiCharacterControl.sensor).foodTarget != null)
            //{
            ((AIRabbitAction)aiCharacterAction).Reproduction();

            //if (((Rabbit)aiCharacterAction.animal).isReproduction)
            //    return TaskStatus.Running;
            //else
            //    return TaskStatus.Failure;
        }
        return TaskStatus.Success;
    }
}