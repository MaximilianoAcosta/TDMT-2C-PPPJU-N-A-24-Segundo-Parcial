using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Unity.VisualScripting.Member;

public class EnemyRangeAttack : MonoBehaviour, IEnemyAttack
{
    [SerializeField] private EnemyBehaviour EnemyBehaviour;
    [SerializeField] private EnemyAnimationController AnimController;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject ProjectileSpawnPoint; 
    [SerializeField] private float AttackWindup;
    [SerializeField] private float AttackDuration;
    [SerializeField] private float AttackCoolDown;
    [SerializeField] private EnemyObjectPool Pool;
    [SerializeField] private AudioSource Asource;
    private void Start()
    {
        Pool = FindObjectOfType<EnemyObjectPool>();
        EnemyBehaviour = GetComponent<EnemyBehaviour>();
        AnimController = GetComponent<EnemyAnimationController>();
    }

    public void Attack()
    {

        StartCoroutine(ActivateAttackHitBox());

    }
    private IEnumerator ActivateAttackHitBox()
    {
        EnemyBehaviour.CanAttack = false;
        EnemyBehaviour.IsAttacking = true;
        AnimController?.SetIsAttacking(true);
        Asource?.PlayOneShot(Asource.clip);
        yield return new WaitForSeconds(AttackWindup);
        activateProjectile();
        //Instantiate(Projectile,ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
        yield return new WaitForSeconds(AttackDuration);
        EnemyBehaviour.IsAttacking = false;
        AnimController?.SetIsAttacking(false);
        StartCoroutine(WaitBetWeenAttacks());
    }
    private IEnumerator WaitBetWeenAttacks()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        EnemyBehaviour.CanAttack = true;
    }

    private void activateProjectile()
    {

        GameObject projectile = Pool.GetFromPool();
        setBullet(projectile);
        projectile.SetActive(true);
    }
    private void setBullet(GameObject bullet)
    {
        bullet.transform.position = ProjectileSpawnPoint.transform.position;
        bullet.transform.rotation = ProjectileSpawnPoint.transform.rotation;
    }
}
