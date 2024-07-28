using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private IEnemyAttack EnemyAttack;
    [SerializeField] private EnemyMovement EnemyMovement;
    [SerializeField] private EnemyDetection EnemyDetection;
    [SerializeField] private string PlayerTag;
    public bool CanAttack { get; set; }
    public bool IsAttacking { get; set; }
    [SerializeField] private bool IsDead;

    public Transform Player;
    public NavMeshAgent Agent;


    private void Start()
    {
        CanAttack = true;
        Player = transform;
        Agent = GetComponent<NavMeshAgent>();
        EnemyAttack = GetComponent<IEnemyAttack>();

    }
    void Update()
    {
        if (!IsDead)
        {
            if (Player.CompareTag(PlayerTag))
            {

                ChasePlayer();
            }
            else
            {
                if (EnemyMovement != null)
                {
                    EnemyMovement.MoveToTarget();
                }
                else
                {
                    Debug.Log("no movement scripts");
                }
                //free roam
            }

        }
        else
        {
            Agent.speed = 0;
            Agent.isStopped = true;
        }
    }
    private void ChasePlayer()
    {

        if (!EnemyMovement.CheckIfTargetIsFar() && Agent.isStopped && CanAttack && !IsAttacking)
        {
            EnemyAttack.Attack();
        }
        else
        {
            EnemyMovement.MoveToTarget();
        }
    }

    public Transform GetPlayer()
    {
        return Player;
    }
    public void SetIsDead(bool b)
    {
         IsDead = b;
    }
}
