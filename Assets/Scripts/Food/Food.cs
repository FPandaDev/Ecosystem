using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float durabilty = 20f;
    [SerializeField] private float durabiltyCurrent;

    public List<Rabbit> rabbits = new List<Rabbit>();

    private void Start()
    {
        durabiltyCurrent = durabilty;
    }

    public void IsBeingEaten()
    {
        durabiltyCurrent -= Time.deltaTime;
        durabiltyCurrent = Mathf.Clamp(durabiltyCurrent, 0, durabilty);

        if (durabiltyCurrent <= 0)
        {
            foreach (Rabbit rabbit in rabbits)
            {
                rabbit.isEating = false;
            }
             
            Destroy(gameObject);
        }
    }
}
