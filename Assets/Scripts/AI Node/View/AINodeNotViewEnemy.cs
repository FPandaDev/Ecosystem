using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("My AI/View")]
public class AINodeNotViewEnemy : AINodeView
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AISensorRabbit)aiCharacterControl._sensor).predatorTarget == null)
            {
                return TaskStatus.Success;
            }
            
        }
        return TaskStatus.Failure;
    }
}
