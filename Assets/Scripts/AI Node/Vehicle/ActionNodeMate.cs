using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("My AI/Move")]
public class ActionNodeMate : AINodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (((AIRabbitVehicle)aiCharacterControl)._animal.IsDead)
            return TaskStatus.Failure;

        ((AIRabbitVehicle)aiCharacterControl).MoveToMate();
        return TaskStatus.Success;
    }
}
