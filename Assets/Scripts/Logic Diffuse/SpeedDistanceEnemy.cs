using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDistanceEnemy : MonoBehaviour
{
    public List<FuzzyFunction> FunctionsMember = new List<FuzzyFunction>();

    public float CalculateFuzzy(float distance)
    {
        float SumaW = 0;
        float MultW = 0;

        for (int i = 0; i < FunctionsMember.Count; i++)
        {
            float y = FunctionsMember[i].Evaluate(distance);
            SumaW += y;
            MultW += y * FunctionsMember[i].SingletonDistance;
        }
        //CALCULO SALIDA
        return (SumaW != 0) ? MultW / SumaW : MultW;
    }
}
