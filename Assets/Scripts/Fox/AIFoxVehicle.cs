using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFoxVehicle : AICharacterVehicle
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

        PositionWander = RandomNavmeshPosition();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        CalculatePositionWander();
    }

    public override void MoveToFood()
    {
        MoveToPosition(((AIFoxSensor)sensor).foodTarget.transform.position);
    }

    public override void MoveToMate()
    {
        animal.ChangeState(STATE.SEARCHMATE);
        MoveToPosition(((AIFoxSensor)sensor).mateTarget.transform.position);
    }

    //public override void Evade()
    //{
    //    animal.ChangeState(STATE.EVADE);
    //    EvadeToPosition(((AIFoxSensor)sensor).predatorTarget.transform.position);
    //}

    public override void Wander()
    {
        animal.ChangeState(STATE.WANDER);
        MoveToPositionWander();
    }

    public override void SearchFood()
    {
        animal.ChangeState(STATE.SEARCHFOOD);
        MoveToPositionWander();
    }

    public override void SearchMate()
    {
        animal.ChangeState(STATE.SEARCHMATE);
        MoveToPositionWander();
    }

    // WANDER FUNCTIONS //
    public override void MoveToPositionWander()
    {
        agent.isStopped = false;

        float dist = (transform.position - PositionWander).magnitude;

        if (dist <= 2f)
        {
            //CalculatePositionWander();
            PositionWander = RandomNavmeshPosition();
        }
        else if (Framerate > arrayRate[index])
        {
            index++;
            index = index % arrayRate.Length;
            //CalculatePositionWander();
            PositionWander = RandomNavmeshPosition();
            Framerate = 0;
        }

        Framerate += Time.deltaTime;
        //UpdatePath(PositionWander);
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

    private Vector3 RandomNavmeshPosition()
    {
        // Obtener una posición aleatoria dentro del NavMesh
        NavMeshHit hit;

        Vector3 randomPosition = Vector3.zero;
        if (NavMesh.SamplePosition(Random.insideUnitSphere * 10f, out hit, 15f, NavMesh.AllAreas))
        {
            randomPosition = hit.position;
        }
        agent.SetDestination(randomPosition);
        return randomPosition;
    }
}
