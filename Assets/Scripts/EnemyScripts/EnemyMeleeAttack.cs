using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAttack : MonoBehaviour, IEnemyAttack
{

    [SerializeField] private EnemyBehaviour EnemyBehaviour;
    [SerializeField] private EnemyAnimationController AnimController;
    [SerializeField] private Collider Collider;
    [SerializeField] private float AttackWindup;
    [SerializeField] private float AttackDuration;
    [SerializeField] private float AttackCoolDown;
    private void Start()
    {
        EnemyBehaviour = GetComponent<EnemyBehaviour>();
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
        AnimController.SetIsAttacking(true);
        yield return new WaitForSeconds(AttackWindup);
        Collider.gameObject.SetActive(true);
        yield return new WaitForSeconds(AttackDuration);
        EnemyBehaviour.IsAttacking = false;
        Collider.gameObject.SetActive(false);
        AnimController.SetIsAttacking(false);
        StartCoroutine(WaitBetWeenAttacks());
    }
    private IEnumerator WaitBetWeenAttacks()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        EnemyBehaviour.CanAttack = true;
    }
}
