using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Move")]
public class VehicleSearchMate : AINodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        //if (((AIRabbitVehicle)aiCharacterControl)._animal.IsDead)
        //    return TaskStatus.Failure;

        if (aiCharacterControl is AIRabbitVehicle)
        {
            ((AIRabbitVehicle)aiCharacterControl).SearchMate();
        }
            
        return TaskStatus.Success;
    }
}
