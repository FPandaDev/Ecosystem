using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Not View")]
public class NotViewMate : AINodeView
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AIRabbitSensor)aiCharacterControl.sensor).mateTarget == null)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
