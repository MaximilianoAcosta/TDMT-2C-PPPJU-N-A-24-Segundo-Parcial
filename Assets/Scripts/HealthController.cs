using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class HealthController : MonoBehaviour
{
    [SerializeField] PlayerDataCreator<float> HealthSource;
    private float MaxHealth;
    public bool alive { get; set; }
    public float Health { get; set; }


    public UnityEvent onDamageTakenEvent;
    public UnityEvent onLifeChangeEvent;
    public UnityEvent onDeathEvent;


    public void Awake()
    {
        alive = true;
        MaxHealth = HealthSource.Value;
        Health = MaxHealth;
    }

    private void OnDisable()
    {
        onDamageTakenEvent = null;
    }
    public void takeDamage(float damage)
    {
        Health -= damage;
        if (Health >= MaxHealth) Health = MaxHealth;
        if (damage > 0)
        {
            onDamageTakenEvent?.Invoke();
        }
        onLifeChangeEvent?.Invoke();

        CheckIfDead();
    }
    private void CheckIfDead()
    {
        if (Health <= 0)
        {
            alive = false;
            onDeathEvent?.Invoke();
        }
    }
    public float GetMaxiHealth()
    {
        return MaxHealth;
    }

}
