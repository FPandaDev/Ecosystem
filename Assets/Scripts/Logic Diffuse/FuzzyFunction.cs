using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FuzzyFunction
{
    public AnimationCurve Functioncurves;
    public float F_y;
    public float SingletonDistance;

    public FuzzyFunction()
    {

    }

    public void Init()
    {
    }
    public float Evaluate(float x)
    {
        F_y = Functioncurves.Evaluate(x);
        return F_y;
    }
}

[System.Serializable]
public class KeyFrameCurve
{
    [Range(0, 1)]
    public float Y;
    public float X;
    public KeyFrameCurve()
    {

    }
}
