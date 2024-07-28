using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAimVisual : MonoBehaviour
{
    [SerializeField] private string EnemyTag;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] private Image CrossHair;
    [SerializeField] private Color NoTargetColor = Color.green;
    [SerializeField] private Color TargetColor = Color.red;
    [SerializeField] GameObject MousePosition;
    [SerializeField] private LayerMask mask;
    private RaycastHit hit;
    private void Update()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxDistance: 2000f, mask))
        {
            //Debug.Log("Hit");
            if (hit.transform.gameObject.CompareTag(EnemyTag))
            {
                CrossHair.color = TargetColor;

            }
            else
            {
                CrossHair.color = NoTargetColor;

            }
                MousePosition.transform.position = hit.point;
        }
        else
        {
            CrossHair.color = NoTargetColor;

        }
    }

    public Vector3 GetHitPoint()
    {
        return MousePosition.transform.position;
    }
}
