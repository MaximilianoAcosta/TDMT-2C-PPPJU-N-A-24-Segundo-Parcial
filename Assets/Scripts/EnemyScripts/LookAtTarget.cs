using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] string playertag;
    private void Start()
    {
        _target = GameObject.FindWithTag(playertag);
    }

    private void Update()
    {
        transform.LookAt(_target.transform.position);
    }
}
