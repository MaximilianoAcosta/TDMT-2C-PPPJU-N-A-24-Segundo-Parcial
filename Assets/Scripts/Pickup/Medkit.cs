using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    [SerializeField] float Heal;
    [SerializeField] AudioSource _AudioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            HealthController controller = other.GetComponent<HealthController>();
            if (controller.Health < controller.GetMaxiHealth())
            {
                controller.takeDamage(Heal * (-1));
                AudioSource.PlayClipAtPoint(_AudioSource.clip, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
