using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveValueManager : MonoBehaviour
{
    [SerializeField] PlayerDataCreator<float> health;
    [SerializeField] PlayerDataCreator<int> RVR_Ammo;
    [SerializeField] PlayerDataCreator<int> SMG_Ammo;
    [Space(10)]
    [SerializeField] float DefaultHealth;
    [SerializeField] int DefaultRVR;
    [SerializeField] int DefaultSMG;
    [Space(10)]
    [SerializeField] HealthController _PlayerHealth;
    [SerializeField] PlayerBullets _PlayerBullets;
    [Space(10)]
    [SerializeField] string _RevolverID;
    [SerializeField] string _SmgID;

    [ContextMenu("ResetDefaultValues")]
    public void ResetDefaultDataSourceValues()
    {
        health.Value = DefaultHealth;
        RVR_Ammo.Value = DefaultRVR;
        SMG_Ammo.Value = DefaultSMG;
    }
    public void SaveDataActualValues()
    {
        health.Value = _PlayerHealth.Health;
        RVR_Ammo.Value = _PlayerBullets.GetAmmo(_RevolverID);
        SMG_Ammo.Value = _PlayerBullets.GetAmmo(_SmgID);
    }
}
