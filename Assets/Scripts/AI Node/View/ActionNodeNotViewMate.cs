using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("My AI/View")]
public class ActionNodeNotViewMate : AINodeView
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AISensorRabbit)aiCharacterControl._sensor).mateTarget == null)
            {
                return TaskStatus.Success;
            }

        }
        return TaskStatus.Failure;
    }
}
