using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangeAttack : MonoBehaviour, IEnemyAttack
{
    [SerializeField] private EnemyBehaviour EnemyBehaviour;
    [SerializeField] private EnemyAnimationController AnimController;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject ProjectileSpawnPoint; 
    [SerializeField] private float AttackWindup;
    [SerializeField] private float AttackDuration;
    [SerializeField] private float AttackCoolDown;
    private void Start()
    {
        EnemyBehaviour = GetComponent<EnemyBehaviour>();
        AnimController = GetComponent<EnemyAnimationController>();
    }

    public void Attack()
    {

        // Debug.Log("Attacked");

        StartCoroutine(ActivateAttackHitBox());


    }
    private IEnumerator ActivateAttackHitBox()
    {
        EnemyBehaviour.CanAttack = false;
        EnemyBehaviour.IsAttacking = true;
        AnimController?.SetIsAttacking(true);
        yield return new WaitForSeconds(AttackWindup);
        Instantiate(Projectile,ProjectileSpawnPoint.transform.position, transform.rotation);
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
}
