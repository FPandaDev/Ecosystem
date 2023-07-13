using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEyeBase : MonoBehaviour
{
    public bool isDrawGizmos = false;

    public int scanFrequency = 30;
    protected float scanInterval;
    protected float scanTimer;

    protected int count = 0;

    public DataView mainDataView = new DataView();

    public int CountEnemyView = 0;

    public List<Animal> mateList = new List<Animal>();


    public Animal animal { get; set; }

    public Transform AimOffset;

    public Animal ViewEnemy;
    public Animal ViewMate;

    #region DISTANCE VIEWs
    #endregion

    public virtual void LoadComponent()
    {
        animal = GetComponent<Animal>();
        mainDataView.Owner = animal;

        scanInterval = 1.0f / scanFrequency;
    }
    public virtual void UpdateScan()
    {
        scanTimer -= Time.deltaTime;
        if (scanTimer < 0)
        {
            scanTimer += scanInterval;
            Scan();
        }

        //if (ViewEnemy != null && ((ViewEnemy.IsDead) || (!ViewEnemy.IsCantView)))
        //{
        //    ViewEnemy = null;
        //}
    }

    public virtual void Scan()
    {
        if (ViewEnemy != null)
        {
            ViewEnemy = null;
        }

        if (ViewMate != null)
        {
            ViewMate = null;
        }

        //if (animal.HurtingMe != null) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, mainDataView.Distance, mainDataView.Scanlayers);
        CountEnemyView = 0;
        count = colliders.Length;

        float min_distMate = float.MaxValue;
        float min_distEnemy = float.MaxValue;

        mateList.Clear();

        for (int i = 0; i < count; i++)
        {
            GameObject obj = colliders[i].gameObject;

            if (IsNotIsThis(obj))
            {
                Animal scanAnimal = obj.GetComponent<Animal>();

                if (scanAnimal != null && obj.activeSelf && /*!scanAnimal.IsDead &&*/
                    /*scanAnimal.IsCantView &&*/ mainDataView.IsInSight(obj.transform))
                {
                    ExtractViewEnemy(ref min_distEnemy, ref min_distMate, scanAnimal);
                }
            }
        }
    }

    private void ExtractViewEnemy(ref float min_distEnemy, ref float min_distMate, Animal _animal)
    {
        Debug.Log("Mate: " + min_distMate + " / Enemy: " + min_distEnemy);

        if (!IsAllies(_animal))
        {
            float dist = (transform.position - _animal.transform.position).sqrMagnitude;


            if (min_distEnemy > dist)
            {
                ViewEnemy = _animal;
                min_distEnemy = dist;
                //Memory = ViewEnemy.position;
            }
            CountEnemyView++;
        }
        else
        {
            mateList.Add(_animal);

            float minDist = float.MaxValue;
            for (int i = 0; i < mateList.Count; i++)
            {
                float distance = Vector3.Distance(mateList[i].transform.position, transform.position);
                if (distance < minDist)
                {
                    ViewMate = mateList[i];
                    minDist = distance;
                }
            }

            //float dist = (transform.position - _animal.transform.position).sqrMagnitude;


            //if (min_distMate > dist)
            //{
            //    ViewMate = _animal;
            //    min_distMate = dist;
            //    //Memory = ViewEnemy.position;
            //}

            //if (ViewMate == null)
            //{
            //    ViewMate = _animal;
            //}        
        }
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

    public virtual bool IsAllies(Animal animalScan)
    {
        if (animal.GetType() == animalScan.GetType())// && animalScan.gender == GENDER.FEMALE)
        {
            return true;
        }
        //print(animalScan);
        return false;
    }

    public virtual bool IsNotIsThis(GameObject obj)
    {
        if (obj.GetInstanceID() == this.gameObject.GetInstanceID())
        {
            return false;
        }       
        return true;
    }

    
}