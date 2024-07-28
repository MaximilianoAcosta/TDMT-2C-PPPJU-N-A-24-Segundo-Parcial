using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnemyOnDeath : MonoBehaviour
{
    [SerializeField] private float disabledelay;
    [SerializeField] private Collider enemyHitbox;
    public void DisableOnDeath()
    {
        enemyHitbox.enabled = false;
        StartCoroutine(DisableAfterTime());
    }
    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(disabledelay);
        gameObject.SetActive(false);
    }
}
