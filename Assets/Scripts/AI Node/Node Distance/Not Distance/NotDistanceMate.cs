using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Not Distance")]
public class NotDistanceMate : AINodeDistance
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (!((AIRabbitSensor)aiCharacterControl.sensor).InRangeMate)
            {
                return TaskStatus.Success;
            }

        }
        return TaskStatus.Failure;
    }
}