using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] PlayerDataCreator<float> HealthSource;
    private float MaxHealth;
    public float Health { get; set; }


    public UnityEvent onDamageTakenEvent;
    public UnityEvent onLifeChangeEvent;
    public UnityEvent onDeathEvent;


    public void Awake()
    {
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
            onDeathEvent?.Invoke();
        }
    }
    public float GetMaxiHealth()
    {
        return MaxHealth;
    }

}
