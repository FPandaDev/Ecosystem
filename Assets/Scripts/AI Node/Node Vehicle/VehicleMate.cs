using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Move")]
public class VehicleMate : AINodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        //if (((AIRabbitVehicle)aiCharacterControl).animal.IsDead)
        //    return TaskStatus.Failure;

        if (aiCharacterControl is AIRabbitVehicle)
        {
            ((AIRabbitVehicle)aiCharacterControl).MoveToMate();
        }

            
        return TaskStatus.Success;
    }
}
