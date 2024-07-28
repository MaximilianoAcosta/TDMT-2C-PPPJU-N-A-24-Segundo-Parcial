using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class GunFire : MonoBehaviour, IWeapons
{
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] GameObject FireOrigin;
    [SerializeField] private GameObject AimTarget;
    [SerializeField] private ParticleSystem fireMuzzle;
    [SerializeField] private string EnemyTag;
    [SerializeField] private PlayerBullets _playerBullets;
    [SerializeField] private AudioSource AudioSource;
    //[SerializeField] private EnemyBleed targetBleed;
    [SerializeField] private float damage;
    [SerializeField] float RateOfFire;
    [SerializeField] private string AmmoType;
    [SerializeField] private int volume;
    [SerializeField] private LayerMask mask;
    private bool CanShoot = true;
    private RaycastHit hit;

    private void OnEnable()
    {
        
        //_input = GetComponent<StarterAssetsInputs>();
        CanShoot = true;

    }
    private void Update()
    {
        Aim();
    }
    public void Shoot()
    {
        if (CanShoot && _playerBullets.GetAmmo(AmmoType) > 0)
        {
            StartCoroutine(WaitBetweenShots());
            _playerBullets.SpendAmmo(AmmoType);
            fireMuzzle.Play();
            AudioSource.PlayOneShot(AudioSource.clip, AudioSource.volume);

            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance: 1000f, mask))
            {
                Debug.DrawRay(transform.position, transform.forward, Color.green, 5);
                if (hit.transform.gameObject.CompareTag(EnemyTag))
                {
                    //targetBleed.onHit(hit.point);
                    hit.transform.TryGetComponent(out HealthController EnemyHealth);
                    if (EnemyHealth != null) EnemyHealth.takeDamage(damage);
                    hit.transform.TryGetComponent(out EnemyMovement movement);
                    movement.LookAtPlayer();
                }
            }
        }
    }
    private IEnumerator WaitBetweenShots()
    {
        CanShoot = false;
        yield return new WaitForSeconds(RateOfFire);
        CanShoot = true;
    }
    private void Aim()
    {
        if (_input.aim)
        {
            transform.LookAt(AimTarget.transform, Vector3.up);
        }
        
    }
}
