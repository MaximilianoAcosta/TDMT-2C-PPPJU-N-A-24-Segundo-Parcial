using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBullets : MonoBehaviour
{
    static Dictionary<string,int> AmmoType = new(); 
    public List<string> AmmoNames = new();

    [SerializeField] string RvrAmmoName;
    [SerializeField] string SmgAmmoName;
    [Space(10)]
    [SerializeField] PlayerDataCreator<int> RVR_Ammo;
    [SerializeField] PlayerDataCreator<int> SMG_Ammo;
    int RvrStartingAmmo;
    int SmgStartingAmmo;
    private TMP_Text RvrAmmoText;
    private TMP_Text SmgAmmoText;
    private void Start()
    {
        RvrStartingAmmo = RVR_Ammo.Value;
        SmgStartingAmmo = SMG_Ammo.Value;
        RvrAmmoText = GameObject.Find(RvrAmmoName).GetComponent<TMP_Text>();
        SmgAmmoText = GameObject.Find(SmgAmmoName).GetComponent<TMP_Text>();
        AmmoNames.Add(RvrAmmoName);
        AmmoNames.Add(SmgAmmoName);
        AmmoType.Add(RvrAmmoName, RvrStartingAmmo);
        AmmoType.Add(SmgAmmoName, SmgStartingAmmo);
       
        RvrAmmoText.SetText(AmmoType[RvrAmmoName].ToString());
        SmgAmmoText.SetText(AmmoType[SmgAmmoName].ToString());
    }
    private void OnDisable()
    {
        AmmoType.Clear();
        AmmoNames.Clear();
    }

    public int GetAmmo(string type)
    {
        AmmoType.TryGetValue(type, out int value);
        return value; 
    }
    public void SetAmmoAmmount(string type, int value)
    {
        AmmoType[type] = value;
    }

    public void SpendAmmo(string type)
    {
  
        AmmoType[type]--;
        SetAmmoText(type);
    }
    public void AddBullets(string type, int ammount)
    {
        AmmoType[type] += ammount;
        SetAmmoText(type);
    }
    private void SetAmmoText(string type)
    {
        switch (type)
        {
            case "RevAmmo":
                RvrAmmoText.SetText(AmmoType["RevAmmo"].ToString());
                break;
            case "SmgAmmo":
                SmgAmmoText.SetText(AmmoType["SmgAmmo"].ToString());
                break;
            default:
                break;
        }
    }
}
