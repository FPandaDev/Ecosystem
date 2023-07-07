using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMale : Rabbit
{
    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateAgeTime();
        UpdateHungerTime();
        InReproduction();
        UpdateState();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    public override void InReproduction()
    {
        if (age != Age.YOUNG) { return; }

        if (mate != null && mate.age == Age.OLD) { isMate = false; }

        if (isMate)
        {
            timerP += Time.deltaTime;

            if (timerP >= timeToPregmant)
            {
                isMate = false;
                timerP = 0;
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.CompareTag("Rabbit") && sensor.mateTarget != null)
        {
            if (other.gameObject == sensor.mateTarget)
            {
                RabbitFemale mateRabbit = other.gameObject.GetComponent<RabbitFemale>();
                mateRabbit.isMate = true;
                mateRabbit.mate = this;
                mate = mateRabbit;
                isMate = true;
            }
        }
    }
}
