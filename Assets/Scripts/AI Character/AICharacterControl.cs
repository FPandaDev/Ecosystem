using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacterControl : MonoBehaviour
{
    public Animal animal;
    public AISensor sensor;

    protected virtual void LoadComponent()
    {
        animal = GetComponent<Animal>();
        sensor = GetComponent<AISensor>();
    }
}
