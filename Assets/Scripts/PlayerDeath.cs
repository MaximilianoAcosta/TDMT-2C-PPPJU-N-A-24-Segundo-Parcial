using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]GameObject deathscreen;
    public void ShowDeathScreen()
    {
        deathscreen.SetActive(true);
    }
}
