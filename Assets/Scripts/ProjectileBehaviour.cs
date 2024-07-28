using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] EntityMovement entityMovement;
    [SerializeField] float speed;

    private void Awake()
    {
        entityMovement.GetComponent<EntityMovement>();
    }
    private void Update()
    {
        entityMovement.SetDirection(speed * Time.deltaTime * transform.forward);
    }
}
