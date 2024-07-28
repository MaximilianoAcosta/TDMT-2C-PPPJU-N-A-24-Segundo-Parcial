using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RecoilGun : MonoBehaviour
{
    [SerializeField] Transform recoilMod;
    [SerializeField]GameObject weapon;
    [SerializeField] private float maxRecoil_x  = -20;
    [SerializeField] private float recoilSpeed  = 10;
    [SerializeField]private float recoil = 0.0f;
    private void Update()
    {
        recoiling();
    }

    private void recoiling()
    {
        if (recoil > 0)
        {
            Quaternion maxRecoil = Quaternion.Euler(maxRecoil_x, 0f, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);
            recoil -= Time.deltaTime;
        }
        else
        {
            recoil = 0f;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, Time.deltaTime * recoilSpeed / 2);
        }
    }
    public void TriggerRecoil()
    {
        recoil += 0.1f;
    }
}
