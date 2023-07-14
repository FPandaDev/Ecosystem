using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Not View")]
public class NotViewFood : AINodeView
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AIRabbitSensor)aiCharacterControl.sensor).foodTarget == null)
            {
                return TaskStatus.Success;
            }
        }
        else if (aiCharacterControl is AIFoxVehicle)
        {
            if (((AIFoxSensor)aiCharacterControl.sensor).foodTarget == null)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}