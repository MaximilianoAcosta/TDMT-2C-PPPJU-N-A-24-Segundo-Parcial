using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float MinDistance;
    [SerializeField] private EnemyBehaviour EnemyBehaviour;
    [SerializeField] private EnemyAnimationController AnimController;
    [SerializeField] private float StunRecovery;
    private float normalSpeed = 4.5f;
    
    private void Start()
    {
        EnemyBehaviour = GetComponent<EnemyBehaviour>();
        AnimController = GetComponent<EnemyAnimationController>();
    }
    private void Update()
    {
        if (EnemyBehaviour.Agent.speed < normalSpeed)
        {
            EnemyBehaviour.Agent.speed += StunRecovery * Time.deltaTime;
        }
    }
    public void MoveToTarget()
    {

        if (CheckIfTargetIsFar())
        {
            
            EnemyBehaviour.Agent.isStopped = false;

            EnemyBehaviour.Agent.SetDestination(EnemyBehaviour.GetPlayer().position);

        }
        else
        {
            EnemyBehaviour.Agent.isStopped = true;
            LookAtPlayer();
        }
        if (AnimController != null)
        {
            AnimController.SetVelocity(EnemyBehaviour.Agent.velocity.magnitude);
        }

    }
    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, EnemyBehaviour.Player.position);
    }
    public bool CheckIfTargetIsFar()
    {
        return GetDistanceToPlayer() > MinDistance;
    }
    public void LookAtPlayer()
    {
        //EnemyBehaviour.Agent.isStopped = true;
        Vector3 targetPosition = EnemyBehaviour.Player.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
    public void GetStun()
    {
        EnemyBehaviour.Agent.speed = EnemyBehaviour.Agent.speed/2;
        
    }
  
}
