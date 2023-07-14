using BehaviorDesigner.Runtime.Tasks.Unity.UnityAnimator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFoxSensor : AISensor
{
    [Header("Targets References")]
    public GameObject foodTarget;
    public GameObject mateTarget;

    private List<GameObject> listRabbits = new List<GameObject>();
    private List<GameObject> listFoxs = new List<GameObject>();

    public bool InRangeFood
    {
        get
        {
            if (foodTarget != null)
                return Vector3.Distance(foodTarget.transform.position, transform.position) < 2.5f;
            else
                return false;
        }
    }

    private void Start()
    {
        base.LoadComponent();
    }

    private void Update()
    {
        base.Execute();
    }

    public override void CheckObjects(GameObject obj)
    {
        string tag = obj.tag;

        switch (tag)
        {
            case "Rabbit":
                listRabbits.Add(obj);
                foodTarget = GOLessDistance(listRabbits);
                break;

            case "Fox":
                //listFoxs.Add(obj);
                //predatorTarget = GOLessDistance(listFoxs);
                break;
        }
    }

    public override void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, layers, QueryTriggerInteraction.Ignore);
        ClearAllList();

        for (int i = 0; i < count; ++i)
        {
            GameObject obj = colliders[i].gameObject;

            if (IsInSight(obj))
            {
                CheckObjects(obj);
            }
        }
    }

    private void ClearAllList()
    {
        listRabbits.Clear();
        listFoxs.Clear();

        foodTarget = null;

        //if (!animal.isReproduction || !InRangeMate)
        //{
        //    mateTarget = null;
        //}

        //if (predatorTarget != null && (transform.position - predatorTarget.transform.position).magnitude > distance)
        //{
        //    predatorTarget = null;
        //}
    }

    private GameObject GOLessDistance(List<GameObject> list)
    {
        GameObject go = null;
        float minDist = 10000000000f;

        for (int i = 0; i < list.Count; i++)
        {
            float distance = Vector3.Distance(list[i].transform.position, transform.position);

            if (distance < minDist)
            {
                go = list[i];
                minDist = distance;
            }
        }
        return go;
    }

    private GameObject SetCouple(List<GameObject> listRabbits)
    {
        List<GameObject> list = new List<GameObject>();

        //for (int i = 0; i < listRabbits.Count; i++)
        //{
        //    RabbitFemale rabbit = listRabbits[i].GetComponent<RabbitFemale>();

        //    if (rabbit != null)
        //    {
        //        //if (rabbit.age == Age.YOUNG && rabbit.InHeat && !rabbit.IsPregnant && !rabbit.isMate && !rabbit.isEating)
        //        if (rabbit.inHeat && !rabbit.isPregnant && rabbit.stateCurrent != STATE.EATING && !rabbit.isReproduction)
        //        {
        //            list.Add(rabbit.gameObject);
        //        }
        //    }
        //}
        return GOLessDistance(list);
    }
}