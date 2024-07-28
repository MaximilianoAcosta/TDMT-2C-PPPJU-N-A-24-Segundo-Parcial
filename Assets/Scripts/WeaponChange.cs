using StarterAssets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] List<GameObject> WeaponObject = new();
    [SerializeField] List<IWeapons> weapons = new();
    [SerializeField] string RifleAimAnimationTag;
    [SerializeField] string MeleeTag;
    [SerializeField] private StarterAssetsInputs _input;
    private Animator _animator;
    private GameObject LastWeapon;

    private const int PistolId = 0;
    private const int SmgId = 1;
    private const int MeleeId = 2;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        foreach (var weapon in WeaponObject)
        {
            if (!weapons.Contains(weapon.GetComponent<IWeapons>()))
            {
                weapons.Add(weapon.GetComponent<IWeapons>());
            }
        }
        //SetDefaultWeapon
        Shooting.SetPlayerWeapon(weapons[PistolId]);
        LastWeapon = WeaponObject[PistolId];
    }


    public void ChangeWeapon(int weapon)
    {
            if (!_input.Aiming && weapons.Count  >= weapon +1 && LastWeapon != WeaponObject[weapon])
            {
                LastWeapon.SetActive(false);
                WeaponObject[weapon].SetActive(true);
                Shooting.SetPlayerWeapon(weapons[weapon]);
                LastWeapon = WeaponObject[weapon];

            }
        SetWeaponAnimation(WeaponObject[SmgId], RifleAimAnimationTag);
        SetWeaponAnimation(WeaponObject[MeleeId], MeleeTag);

    }

    private void SetWeaponAnimation(GameObject weapon, string tag)
    {
        if (LastWeapon == weapon)
        {
            _animator.SetBool(tag, true);
        }
        else
        {
            _animator.SetBool(tag, false);
        }
    }

    public void OnChangeWeapon(InputValue value)
    {
        if (value.isPressed)
        {
            ChangeWeapon(PistolId);

        }

    }
    public void OnChangeWeapon2(InputValue value)
    {
        if (value.isPressed)
        {
            ChangeWeapon(SmgId);
        
        }

    }
    public void OnChangeWeapon3(InputValue value)
    {
        if (value.isPressed)
        {
            ChangeWeapon(MeleeId);

        }

    }
}

    /*public void ChangeWeapon(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            int.TryParse(ctx.control.name, out int numKeyValue);
            if( LastWeapon != WeaponObject[numKeyValue - 1])
            {
                LastWeapon.SetActive(false);
                WeaponObject[numKeyValue - 1].SetActive(true);
                Shooting.SetPlayerWeapon(weapons[numKeyValue - 1]);
                LastWeapon = WeaponObject[numKeyValue - 1];
            }
        }

    }*/