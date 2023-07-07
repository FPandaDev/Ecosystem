using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterVehicle : AICharacterControl
{
    

    protected override void LoadComponent()
    {
        base.LoadComponent();     
    }

    public virtual void MoveToPosition(Vector3 target)
    {
        agent.isStopped = false;
        agent.SetDestination(target);
    }

    public virtual void EvadeToPosition(Vector3 target)
    {
        Vector3 dir = transform.position - target;
        Vector3 newPos = transform.position + dir.normalized * 3;

        agent.SetDestination(newPos);
    }

    public virtual void MoveToFood() { }
    public virtual void MoveToMate() { }
    public virtual void SearchFood() { }
    public virtual void SearchMate() { }
    public virtual void Wander() { }
    public virtual void MoveToPositionWander() { }
    public virtual void CalculatePositionWander() { }
}
