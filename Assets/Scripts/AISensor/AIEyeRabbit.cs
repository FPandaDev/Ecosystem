using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIEyeRabbit : AIEyeBase
{
    public DataView actionDataView = new DataView();

    public Animal mateInRange;

    private void Start()
    {
        this.LoadComponent();
    }

    private void Update()
    {
        this.UpdateScan();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    public override void UpdateScan()
    {
        base.UpdateScan();

        if (ViewMate != null)
        {
            if (actionDataView.IsInSight(ViewMate.transform))
            {
                mateInRange = ViewMate;
            }
            else
            {
                mateInRange = null;
            }
        }
    }

    private void OnValidate()
    {
        mainDataView.CreateMesh();
        actionDataView.CreateMesh();
    }

    private void OnDrawGizmos()
    {
        if (isDrawGizmos)
        {
            mainDataView.OnDrawGizmos();
            actionDataView.OnDrawGizmos();
        }
    }
}
