using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("AI Node/Action")]
public class ActionEat : AINodeAction
{
    public override TaskStatus OnUpdate()
    {
        if (aiCharacterAction is AIRabbitAction)
        {          
            ((AIRabbitAction)aiCharacterAction).Eat();
        }
        else if (aiCharacterAction is AIFoxAction)
        {
            ((AIFoxAction)aiCharacterAction).Eat();
        }

        return TaskStatus.Success;
    }
}