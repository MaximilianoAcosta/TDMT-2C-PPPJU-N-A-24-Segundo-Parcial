using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFloat : MonoBehaviour
{
    [SerializeField] float amp;
    [SerializeField] float speed;
    [SerializeField] GameObject parent;
    
    
    void Update()
    {
        transform.position = new Vector3(parent.transform.position.x, Mathf.Sin(Time.time * speed) * amp + parent.transform.position.y, parent.transform.position.z);
    }
}
