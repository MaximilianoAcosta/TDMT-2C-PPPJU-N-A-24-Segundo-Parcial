using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    
    private Vector3 direction;
    public Rigidbody rb;
    public float speed;

    public void SetDirection(Vector3 dir)
    {
        direction=dir;
    }
    private void FixedUpdate()
    {
        Vector3 force = new Vector3(direction.x * speed , rb.velocity.y , direction.z * speed);
        if (rb) { rb.velocity = force; }
        //transform.position += direction;
    }
}
