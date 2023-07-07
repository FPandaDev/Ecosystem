using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterControl : MonoBehaviour
{
    public Animal animal;
    public AISensor sensor;
    public NavMeshAgent agent;
    protected virtual void LoadComponent()
    {
        animal = GetComponent<Animal>();
        sensor = GetComponent<AISensor>();
        agent = GetComponent<NavMeshAgent>();
    }
}
