using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("My AI/Distance")]
public class AINodeDistanceFood : AINodeDistance
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AISensorRabbit)aiCharacterControl._sensor).InRangeFood)
            {
                return TaskStatus.Success;
            }

        }
        return TaskStatus.Failure;
    }
}
