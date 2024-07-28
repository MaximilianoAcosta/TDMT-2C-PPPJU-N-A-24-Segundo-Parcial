using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDeathParticle : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }
}
