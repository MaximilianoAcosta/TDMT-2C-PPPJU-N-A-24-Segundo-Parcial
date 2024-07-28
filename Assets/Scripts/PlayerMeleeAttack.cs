using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour, IWeapons
{

    [SerializeField] StarterAssetsInputs _input;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject Collider;
    [SerializeField] private int Damage;
    [SerializeField] private float Duration;
    [SerializeField] private float Cooldown;

    [SerializeField] private string AttackAnimationTag;

    private bool CanAttack = true;

    private void Start()
    {
        Collider.SetActive(false);
    }
    public void Shoot()
    {
        if(_input.Aiming && CanAttack)
        {
            StartCoroutine(MeleeAttack());
        }
    }

    private IEnumerator MeleeAttack()
    {
        CanAttack = false;
        Collider.SetActive(true);
        _animator.SetTrigger(AttackAnimationTag);
        yield return new WaitForSeconds(Duration);
        Collider.SetActive(false); 
        yield return new WaitForSeconds(Cooldown);
        CanAttack = true;
    }
}
