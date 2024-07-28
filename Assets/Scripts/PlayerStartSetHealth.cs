using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartSetHealth : MonoBehaviour
{
    [SerializeField] PlayerDataCreator<float> PlayerActualHealth;
    [SerializeField] HealthController HealthController;

    private void Start()
    {
        HealthController.Health = PlayerActualHealth.Value;
    }
}
