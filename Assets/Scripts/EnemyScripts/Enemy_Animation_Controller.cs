using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string PIsAttacking;
    [SerializeField] string PVelocity;
    [SerializeField] string PIsDead;
    [SerializeField] string PTookDamage;

    public void SetIsAttacking(bool b)
    {
        animator.SetBool(PIsAttacking, b);
    }
    public void SetVelocity(float velocity)
    {
        animator.SetFloat(PVelocity, velocity);
    }
    public void SetIsDead(bool b)
    {
        animator.SetBool(PIsDead, b);
    }
    public void SetTookDamage()
    {
        animator.SetTrigger(PTookDamage);
    }
}
