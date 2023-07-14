using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitFemale : Rabbit
{
    [Header("REPRODUCTION")]
    [SerializeField] private float heatTime = 100f;
    [SerializeField] private float gestationTime = 100f;

    public bool inHeat = false;
    public bool isPregnant = false;

    public float heatCurrent;
    public float gestationCurrent;

    private RabbitMale target;

    [Header("PREFABS")]
    [SerializeField] private Rabbit rabbitMale;
    [SerializeField] private Rabbit rabbitFemale;

    public Image fillHunger;
    public Image fillHeat;
    public Image fillGestation;

    private void Start()
    {
        LoadComponent();

        heatCurrent = 0f;
        gestationCurrent = 0f;

        inHeat = false;
        isPregnant = false;

        fillHeat.gameObject.SetActive(false);
        fillGestation.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateAge();
        UpdateHungerLevel();

        fillHunger.fillAmount = hungerCurrent / hungerLevel;
        stateText.text = stateCurrent.ToString();

        if (age == AGE.YOUNG)
        {          
            if (!isPregnant)
            {
                fillHeat.gameObject.SetActive(true);
                fillGestation.gameObject.SetActive(false);
            }
            else if (isPregnant)
            {
                fillHeat.gameObject.SetActive(false);
                fillGestation.gameObject.SetActive(true);
            }

            fillHeat.fillAmount = heatCurrent / heatTime;
            fillGestation.fillAmount = gestationCurrent / gestationTime;

            UpdateHeat();
            UpdatePregmant();
        }    
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    private void UpdateHeat()
    {
        if (!inHeat && !isPregnant)
        {
            heatCurrent += Time.deltaTime;

            if (heatCurrent >= heatTime)
            {
                //heatCurrent = 0f;
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
                CreateRabbits();
                

                gestationCurrent = 0f;
                inHeat = false;
                isPregnant = false;
            }
        }
    }

    public override void UpdateReprodution()
    {       
        if (stateCurrent == STATE.REPRODUCTION)
        {
            timeToPregmant += Time.deltaTime;
            RotateMate();

            if (timeToPregmant >= ToPregmant)
            {
                heatCurrent = 0f;
                isPregnant = true;
                inHeat = false;              
                isReproduction = false;
            }

            if (!target.isReproduction)
            {
                isReproduction = false;
            }
        }
    }

    public void SetViewMate(RabbitMale _target)
    {
        target = _target;
        ChangeState(STATE.REPRODUCTION);      
    }

    private void RotateMate()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
    }

    private void CreateRabbits()
    {
        int count = Random.Range(1, 5);

        for (int i = 0; i < count; i++)
        {
            bool gender = Random.value < 0.5f;

            Debug.Log("crear conejos");
            Rabbit rabbit = Instantiate(gender ? rabbitMale : rabbitFemale, transform.position, Quaternion.identity);
            rabbit.age = AGE.CHILDREN;
        }
    }

    public override void ChangeState(STATE newState)
    {
        if (newState == stateCurrent) { return; }

        stateCurrent = newState;

        switch (newState)
        {
            case STATE.EATING:
                break;

            case STATE.REPRODUCTION:
                isReproduction = true;
                timeToPregmant = 0f;
                break;
        }
    }
}