using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnerPortal;
    [SerializeField] int AmmountToSpawn;
    [SerializeField] List<GameObject> EnemiesToSpawn;
    [SerializeField] private int SpawnDelay;
    [SerializeField] private string PlayerTag;
    [SerializeField] private BoxCollider starter;
    private bool StartedSpawning;
    private bool AbleToSpawn;
    private int Spawned;

    public UnityEvent OnSpawnerClear;

    private void Start()
    {
        StartedSpawning = false;
        Spawned = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag) && !StartedSpawning)
        {
            AbleToSpawn = true;
            Debug.Log("Spawn Started");
            StartedSpawning = true;
        }
    }
    private void Update()
    {
        if (AbleToSpawn && Spawned < AmmountToSpawn)
        {
            Debug.Log("EnemySpawned");
            StartCoroutine(SpawnEnemy());
        }
        if (Spawned >= AmmountToSpawn)
        {
            OnSpawnerClear?.Invoke();
        }
    }
    private IEnumerator SpawnEnemy()
    {
        AbleToSpawn = false;
        Spawned++;
        int enemy = Random.Range(0, EnemiesToSpawn.Count);
        int Portal = Random.Range(0, spawnerPortal.Count);
        NavMeshHit hit;
        if(NavMesh.SamplePosition(spawnerPortal[Portal].transform.position,out hit,100f,NavMesh.AllAreas))
        Instantiate(EnemiesToSpawn[enemy], hit.position,transform.rotation);
        yield return new WaitForSeconds(SpawnDelay);
        AbleToSpawn = true;
    }
}
