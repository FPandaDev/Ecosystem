using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Not View")]
public class NotViewEnemy : AINodeView
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AIRabbitSensor)aiCharacterControl.sensor).predatorTarget == null)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
