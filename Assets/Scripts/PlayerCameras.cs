using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerCameras : MonoBehaviour
{
    [SerializeField] private GameObject NormalCamera;
    [SerializeField] private GameObject AimCamera;
    private StarterAssetsInputs _input;
    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _input.onClickPressed += ActivateCamera;
    }
    public void ActivateCamera()
    {
        if (NormalCamera.activeSelf)
        {
            AimCamera.SetActive(true);
            NormalCamera.SetActive(false);
        }
        else
        {
            AimCamera.SetActive(false);
            NormalCamera.SetActive(true);
        }
    }
}
