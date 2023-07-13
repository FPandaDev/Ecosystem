using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/View")]
public class ViewEnemy : AINodeView
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((AIRabbitSensor)aiCharacterControl.sensor).predatorTarget != null)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
