using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Move")]
public class VehicleSearchFood : AINodeVehicle
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
            ((AIRabbitVehicle)aiCharacterControl).SearchFood();
        }
        
        return TaskStatus.Success;
    }
}