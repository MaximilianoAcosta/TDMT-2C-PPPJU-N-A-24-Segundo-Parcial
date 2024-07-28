using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
   [SerializeField]AudioSource m_AudioSource;
    private void Start()
    {
        m_AudioSource.playOnAwake = true;
    }
    private void OnDisable()
    {
        m_AudioSource.Stop();
    }
}
