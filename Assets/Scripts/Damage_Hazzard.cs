using UnityEngine;

public class Damage_Hazzard : MonoBehaviour
{
    [SerializeField] private string tagToCollide;
    [SerializeField] private float damage;
    [SerializeField] private HealthController PlayerHealth;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(tagToCollide))
        {
            PlayerHealth = other.GetComponent<HealthController>();
          
            PlayerHealth.takeDamage(damage);
        }
    }
}
