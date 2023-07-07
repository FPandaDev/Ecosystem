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

    private AISensorRabbit sensor;

    private void Start()
    {
        this.LoadComponent();       
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
        indexPath = 0;
        ResetArray();

        sensor = _sensor as AISensorRabbit;
    }

    public void MoveToEnemy()
    {
        //if (_sensor.enemyRef != null)
        //{
        //    this.MoveToPosition(_sensor.enemyRef.transform.position);
        //}
    }

    public void MoveToFood()
    {
        //AISensorRabbit sensor = _sensor as AISensorRabbit;

        //if (sensor.foodTarget != null)
        //{
            _animal.state = State.SEARCHFOOD;
            MoveToPosition(sensor.foodTarget.transform.position);
        //}
    }
    public void MoveToMate()
    {
        //AISensorRabbit sensor = _sensor as AISensorRabbit;

        //if (sensor.mateTarget != null)
        //{
            _animal.state = State.SEARCHMATE;
            MoveToPosition(sensor.mateTarget.transform.position);
        //}
    }

    public void EvadeToPosition()
    {
        //AISensorRabbit sensor = _sensor as AISensorRabbit;

        //if (sensor.predatorTarget != null)
        //{
            _animal.state = State.EVADE;
            EvadeToPosition(sensor.predatorTarget.transform.position);
        //}
    }

    public override void MoveToPosition(Vector3 target)
    {
        _agent.SetDestination(target);
    }

    public override void EvadeToPosition(Vector3 target)
    {
        base.EvadeToPosition(target);
    }

    // WANDER FUNCTIONS //
    public override void MoveToPositionWander()
    {
        _animal.state = State.WANDER;

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
        //if (_sensorEye.ViewEnemy != null)
        RandomPoint(transform.position, RangleWander, out PositionWander);
    }

    public void UpdatePath(Vector3 position)
    {
        if (!this._agent.enabled) return;

        elapsed += Time.deltaTime;

        if (elapsed > 1f)
        {
            elapsed -= 1.0f;
            _agent.ResetPath();
            NavMeshPath path2 = new NavMeshPath();
            NavMesh.CalculatePath(transform.position, position, NavMesh.AllAreas, path2);
            _agent.SetPath(path2);
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

    /*public override Vector3 CalculatePositionEvade()
    {
        Vector3 back = Vector3.zero;
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit rayHit;

        if (Physics.Raycast(ray, out rayHit, 5))
        {
            Vector3 bounceDirection = Vector3.Reflect(transform.forward, rayHit.normal);
            back = rayHit.point + bounceDirection * 2;
        }

        return back;
    }

    public override void MoveToPositionCommand(Vector3 position)
    {
        UpdatePath(position);
    }*/
}
