using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private static IWeapons _Weapon;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _input.onLeftClickPressed += Shoot;
    }
    public void Shoot()
    {
        _Weapon.Shoot();  
    }

    public static void SetPlayerWeapon(IWeapons weapon)
    {

        _Weapon = weapon;
    }
}

