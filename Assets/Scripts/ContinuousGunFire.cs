using StarterAssets;
using System.Collections;
using UnityEngine;

public class ContinuousGunFire : MonoBehaviour, IWeapons
{
    [SerializeField] private PlayerBullets _playerBullets;
    [SerializeField] private ParticleSystem fireMuzzle;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] private GameObject AimTarget;

    [SerializeField] private string AmmoType;
    [SerializeField] private string EnemyTag;
    
    [SerializeField] private float damage;
    [SerializeField] float RateOfFire;

    [SerializeField] private LayerMask mask;
    private bool CanShoot = false;
    private bool Shooting = false;
    private RaycastHit hit;
    private void Update()
    {
        Aim();
        toggleShot();
        if (CanShoot && _playerBullets.GetAmmo(AmmoType) > 0)
        {
            StartCoroutine(WaitBetweenShots());
        }
        if (!_input.Aiming)
        {
            Shooting = false;
            CanShoot = false;
        }
        if (_playerBullets.GetAmmo(AmmoType) <= 0)
        {
            AudioSource.Stop();
        }
    }
    public void Shoot()
    {
        Debug.Log("enter shoot");
        if (_input.Aiming && !Shooting && _playerBullets.GetAmmo(AmmoType) > 0)
        {
            Shooting = true;
            CanShoot = true;
        }
        else 
        {
            Shooting = false;

        }

        Debug.Log("Shooting" + Shooting);

    }
    public void toggleShot()
    {
        if (Shooting )
        {
            if (!AudioSource.isPlaying) AudioSource.Play();
        }
        else
        {
            StopAllCoroutines();
            CanShoot = false;
            if (AudioSource.isPlaying) { AudioSource.Stop(); }
        }

    }
    private IEnumerator WaitBetweenShots()
    {
        CanShoot = false;

        _playerBullets.SpendAmmo(AmmoType);
        fireMuzzle.Play();
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 1000f, mask))
        {
            if (hit.transform.gameObject.CompareTag(EnemyTag))
            {
                //targetBleed.onHit(hit.point);
                hit.transform.TryGetComponent(out HealthController EnemyHealth);
                if (EnemyHealth != null) EnemyHealth.takeDamage(damage);
                hit.transform.TryGetComponent(out EnemyMovement movement);
                movement.LookAtPlayer();
            }
        }
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
