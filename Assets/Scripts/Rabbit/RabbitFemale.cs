using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitFemale : Rabbit
{
    [Header("REPRODUCTION")]
    [SerializeField] private bool isPregnant = false;
    [SerializeField] private float heat = 100f;
    [SerializeField] private float gestation = 100f;

    [SerializeField] private Slider sliderInHeat;
    [SerializeField] private Slider sliderGestation;

    [SerializeField] private Rabbit rabbitMale;
    [SerializeField] private Rabbit rabbitFemale;

    private float heatTime = 0f;
    private float gestationTime = 0f;

    public bool InHeat { get { return heatTime >= heat; } }
    public bool IsPregnant { get { return isPregnant; } set { isPregnant = value; } }


    //public GameObject Mate { set { mate = value; } }

    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateAgeTime();
        UpdateHungerTime();
        UpdateGestationTime();
        InReproduction();
        UpdateState();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
        isPregnant = false;
        heatTime = 0f;
        gestationTime = 0f;
    }

    public override void InReproduction()
    {
        if (age != Age.YOUNG) { return; }

        if (mate != null)
        {
            if (mate.age == Age.OLD)
            {
                isMate = false;
            }
        }

        if (isMate)
        {
            timerP += Time.deltaTime;

            Vector3 direction = mate.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

            if (timerP >= timeToPregmant)
            {
                IsPregnant = true;
                isMate = false;
                timerP = 0;
            }
        }
    }

    private void UpdateGestationTime()
    {
        if (age == Age.YOUNG)
        {
            if (!InHeat && !isPregnant)
            {
                heatTime += Time.deltaTime;
                heatTime = Mathf.Clamp(heatTime, 0, heat);
                sliderInHeat.value = heatTime / heat;
            }

            if (isPregnant)
            {
                gestationTime += Time.deltaTime;
                gestationTime = Mathf.Clamp(gestationTime, 0, gestation);
                sliderGestation.value = gestationTime / gestation;

                if (gestationTime >= gestation)
                {
                    CreateChildren();
                    heatTime = 0f;
                    gestationTime = 0f;
                    IsPregnant = false;
                }
            }

            sliderInHeat.gameObject.SetActive(!isPregnant);
            sliderGestation.gameObject.SetActive(isPregnant);
        }
    }

    private void CreateChildren()
    {
        int countChildren = Random.Range(1, 4);

        for (int i = 0; i < countChildren; i++)
        {
            bool genere = Random.value < 0.5f;

            if (genere)
            {
                Rabbit rabbit = Instantiate(rabbitMale, transform.position, Quaternion.identity);
            }             
            else
            {
                Rabbit rabbit = Instantiate(rabbitFemale, transform.position, Quaternion.identity);
            }            
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}