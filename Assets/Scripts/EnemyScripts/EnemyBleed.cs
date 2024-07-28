using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBleed : MonoBehaviour
{
    [SerializeField] private ParticleSystem blood;

    public void onHit(Vector3 enemyPosition)
    {
        blood.transform.position = enemyPosition;
        blood.Play();
    }
}
