using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitFemale : Rabbit
{
    [Header("REPRODUCTION")]
    [SerializeField] private float heatTime = 100f;
    [SerializeField] private float gestationTime = 100f;

    public bool inHeat = false;
    public bool isPregnant = false;

    public float heatCurrent;
    public float gestationCurrent;

    private void Update()
    {
        UpdateHunger();
        UpdateHeat();
        UpdatePregmant();
    }

    private void UpdateHeat()
    {
        if (!inHeat && !isPregnant)
        {
            heatCurrent += Time.deltaTime;

            if (heatCurrent >= heatTime)
            {
                heatCurrent = 0f;
                inHeat = true;
            }        
            //heatCurrent = Mathf.Clamp(heatCurrent, 0f, heatTime);
            //inHeat = heatCurrent >= heatTime;
        }   
    }

    private void UpdatePregmant()
    {
        if (isPregnant)
        {
            gestationCurrent += Time.deltaTime;

            if (gestationCurrent >= gestationTime)
            {
                // Función para crear conejos

                gestationCurrent = 0f;
                isPregnant = false;
            }
        }
    }
}