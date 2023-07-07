using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Not Distance")]
public class NotDistanceFood : AINodeDistance
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (!((AIRabbitSensor)aiCharacterControl.sensor).InRangeFood)
            {
                return TaskStatus.Success;
            }

        }
        return TaskStatus.Failure;
    }
}