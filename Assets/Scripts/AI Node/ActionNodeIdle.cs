using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("My AI/Idle")]

public class ActionNodeIdle : AINode
{
    public override void OnStart()
    {
        base.OnStart();
        aiCharacterControl = GetComponent<AICharacterControl>();
    }

    public override TaskStatus OnUpdate()
    {
        if (aiCharacterControl is AIRabbitVehicle)
        {
            if (((Rabbit)aiCharacterControl._animal).isMate || ((Rabbit)aiCharacterControl._animal).isEating)
            {
                if (((AISensorRabbit)aiCharacterControl._sensor).predatorTarget != null)
                {
                    ((AIRabbitVehicle)aiCharacterControl)._agent.isStopped = true;
                    return TaskStatus.Running;
                }
                else
                {
                    ((AIRabbitVehicle)aiCharacterControl)._agent.isStopped = false;

                }
            }
            else
            {
                ((AIRabbitVehicle)aiCharacterControl)._agent.isStopped = false;
            }
        }
        return TaskStatus.Failure;
    }
}
