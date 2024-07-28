using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] CameraShake Camera1;
    [SerializeField] CameraShake Camera2;
   
    public void ShakeCameras()
    {
        if (Camera1.isActiveAndEnabled)
        {
            Camera1.ShakeCamera(1);
        }
        if (Camera2.isActiveAndEnabled)
        {
            Camera2.ShakeCamera(1);
        }
    }
    
}
