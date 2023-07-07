using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Action")]
public class ActionEat : AINodeAction
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterAction is AIRabbitAction)
        {
            //if (((AIRabbitSensor)aiCharacterControl.sensor).foodTarget != null)
            //{
                ((AIRabbitAction)aiCharacterAction).Eat();

                //if (((Rabbit)aiCharacterAction.animal).isEating)
                //    return TaskStatus.Running;
                //else
                //    return TaskStatus.Failure;
            //}
        }
        return TaskStatus.Success;
    }
}