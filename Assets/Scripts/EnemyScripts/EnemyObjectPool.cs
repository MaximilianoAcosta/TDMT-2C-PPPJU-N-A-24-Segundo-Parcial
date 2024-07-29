using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] List<GameObject> projectiles = new List<GameObject>();

    [SerializeField] int _startingAmmount;

    private void Start()
    {
        for (int i = 0; i < _startingAmmount; i++) 
        { 
            GameObject item = Instantiate(projectile);
            item.SetActive(false);
            projectiles.Add(item);
        }
    }

    public GameObject GetFromPool()
    {
        foreach (GameObject go in projectiles)
        {
            if (!go.activeSelf)
            {
                return go;
            }
        }
        GameObject item = Instantiate(projectile);
        item.SetActive(false);
        projectiles.Add(item);
        return item;
    }
}
