using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterControl : MonoBehaviour
{
    public Animal _animal;
    public AISensor _sensor;

    public virtual void LoadComponent()
    {
        _animal = GetComponent<Animal>();
        _sensor = GetComponent<AISensor>();
    }
}
