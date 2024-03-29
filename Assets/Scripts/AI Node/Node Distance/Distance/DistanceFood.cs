using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Distance")]
public class DistanceFood : AINodeDistance
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AIRabbitSensor)aiCharacterControl.sensor).InRangeFood)
            {
                return TaskStatus.Success;
            }

        }
        else if (aiCharacterControl is AIFoxVehicle)
        {
            if (((AIFoxSensor)aiCharacterControl.sensor).InRangeFood)
            {
                return TaskStatus.Success;
            }

        }
        return TaskStatus.Failure;
    }
}