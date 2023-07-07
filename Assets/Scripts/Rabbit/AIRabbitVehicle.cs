using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRabbitVehicle : AICharacterVehicle
{
    public float RangleWander;

    public int index;
    public float Framerate;
    public float[] arrayRate = new float[10];

    protected Vector3 PositionWander;

    protected int indexPath = 0;
    protected float elapsed = 0.0f;

    private void Start()
    {
        LoadComponent();
        ResetArray();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        CalculatePositionWander();
    }

    public override void MoveToFood()
    {     
        MoveToPosition(((AIRabbitSensor)sensor).foodTarget.transform.position);
    }

    public override void MoveToMate()
    {
        animal.ChangeState(State.SEARCHMATE);
        MoveToPosition(((AIRabbitSensor)sensor).mateTarget.transform.position);
    }

    public override void Wander()
    {
        animal.ChangeState(State.WANDER);
        MoveToPositionWander();
    }

    public override void SearchFood()
    {
        animal.ChangeState(State.SEARCHFOOD);
        MoveToPositionWander();
    }

    public override void SearchMate()
    {
        animal.ChangeState(State.SEARCHMATE);
        MoveToPositionWander();
    }

    // WANDER FUNCTIONS //
    public override void MoveToPositionWander()
    {
        agent.isStopped = false;
        
        float dist = (transform.position - PositionWander).magnitude;

        if (dist <= 2f)
        {
            CalculatePositionWander();
        }
        else if (Framerate > arrayRate[index])
        {
            index++;
            index = index % arrayRate.Length;
            CalculatePositionWander();
            Framerate = 0;
        }

        Framerate += Time.deltaTime;
        UpdatePath(PositionWander);
    }

    public override void CalculatePositionWander()
    {      
        RandomPoint(transform.position, RangleWander, out PositionWander);
    }

    public void UpdatePath(Vector3 position)
    {
        if (!this.agent.enabled) return;

        elapsed += Time.deltaTime;

        if (elapsed > 1f)
        {
            elapsed -= 1.0f;
            agent.ResetPath();
            NavMeshPath path2 = new NavMeshPath();
            NavMesh.CalculatePath(transform.position, position, NavMesh.AllAreas, path2);
            agent.SetPath(path2);
        }
    }

    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        result = center + Random.insideUnitSphere * range;
        result.y = center.y;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(result, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            Vector3 dir = (hit.position - center);

            Ray ray = new Ray(center, dir.normalized);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, dir.magnitude))
            {
                result = rayHit.point + rayHit.normal * 2;
            }
            return true;
        }
        return false;
    }

    private void ResetArray()
    {
        for (int i = 0; i < arrayRate.Length; i++)
        {
            arrayRate[i] = Random.Range(10, 15);
        }
    }
}
