using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkullSpawnDeadProp : MonoBehaviour
{
    [SerializeField] GameObject Deadskull;
    [SerializeField] GameObject Particles;
   public void SpawnSkullOnDeath()
    {
        Instantiate(Particles, transform.position, transform.rotation);
        Instantiate(Deadskull,transform.position,transform.rotation);
    }
}
