using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterVehicle : AICharacterControl
{
    public NavMeshAgent _agent;

    public override void LoadComponent()
    {
        base.LoadComponent();
        _agent = GetComponent<NavMeshAgent>();
    }

    public virtual void MoveToPosition(Vector3 target)
    {
        _agent.SetDestination(target);
    }

    public virtual void EvadeToPosition(Vector3 target)
    {
        Vector3 dir = transform.position - target;
        Vector3 newPos = transform.position + dir.normalized * 3;

        _agent.SetDestination(newPos);
    }

    public virtual void CalculatePositionWander() { }
    public virtual void MoveToPositionWander() { }

    //public virtual Vector3 CalculatePositionEvade() { return Vector3.zero; }
    //public virtual void MoveToPositionCommand(Vector3 position) { }
}
