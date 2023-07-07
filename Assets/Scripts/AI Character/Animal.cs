using UnityEngine;
using UnityEngine.UI;

public enum State { WANDER, EATING, REPRODUCTION, SEARCHFOOD, SEARCHMATE, EVADE}
public enum Age { CHILD, YOUNG, OLD }

public class Animal : MonoBehaviour
{
    [Header("ATTRIBUTES")]
    public State state;
    public Age age;

    [SerializeField] protected float ageTime = 0f;
    [SerializeField] protected float healtMax = 100f;
    [SerializeField] protected float speedMin = 1.5f;
    [SerializeField] protected float speedMax = 3.5f;
    [SerializeField] protected float hunger = 100f;
    [SerializeField] protected float thirst = 100f;

    [SerializeField] protected float staminaMin = 40f;
    [SerializeField] protected float staminaMax = 100f;
    [SerializeField] protected float timeToPregmant = 3f;
    

    [Header("UI")]
    [SerializeField] protected Slider sliderHungry;
   

    protected float healthCurrent;
    protected float hungerLevel;
    protected float thirstLevel;
    protected float staminaCurrent;
    protected float timerP;

    public bool SearchHunger { get { return hungerLevel < 80f; } }
    public bool HungerPriority { get { return hungerLevel < 30f; } }
    public bool IsDead { get { return healthCurrent <= 0; } }
}