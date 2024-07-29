using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] int duration;
    [SerializeField] int LayerNumber;
    private Vector3 direction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerNumber) 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
    }
    private void Update()
    {
        direction = (speed * Time.deltaTime * transform.forward);
    }

    private void FixedUpdate()
    {
        if (rb) { rb.velocity = direction; }
    }
    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
