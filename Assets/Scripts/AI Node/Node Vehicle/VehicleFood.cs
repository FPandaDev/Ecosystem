using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Move")]
public class VehicleFood : AINodeVehicle
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
            ((AIRabbitVehicle)aiCharacterControl).MoveToFood();
        }
        else if (aiCharacterControl is AIFoxVehicle)
        {
            ((AIFoxVehicle)aiCharacterControl).MoveToFood();
        }

        return TaskStatus.Success;
    }
}