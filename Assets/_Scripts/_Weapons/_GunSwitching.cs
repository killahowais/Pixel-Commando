using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GunSwitching : MonoBehaviour
{
    // gun data 
    [SerializeField] _GunData _ak47;
    [SerializeField] _GunData _pistol;
    [SerializeField] _GunData _miniGun;
    [SerializeField] _GunData _currentGunData;

    [SerializeField] Transform _shootPos;
    [SerializeField] SpriteRenderer _gunSprite;

    private _GunData _currentGunData;


    void Start()
    {
        SwitchToPistol();  // Default to AK47 at the start
    }



    IEnumerator SetGunData(_GunData newGunData)
    {
        _currentGunData = newGunData;

        GunName = _currentGunData._gunName;
        CurrentAmmo = _currentGunData._currentAmmo;
        MaxAmmo = _currentGunData._maxAmmo;
        Damage = _currentGunData._damage;
        ShootCoolDown = _currentGunData._shootCoolDown;
        ReloadTime = _currentGunData._reloadTime;
        ShootingRange = _currentGunData._shootingRange;
        IsAutomatic = _currentGunData._isAutomatic;

        yield return null;
    }


    public void SwitchToPistol()
    {
        _currentGunData._currentAmmo = CurrentAmmo;
        StartCoroutine(SetGunData(_pistol));
    }

    public void SwitchToAK47()
    {
        _currentGunData._currentAmmo = CurrentAmmo;
        StartCoroutine(SetGunData(_ak47));

    }
    public void SwitchToMiniGun()
    {
        _currentGunData._currentAmmo = CurrentAmmo;
        StartCoroutine(SetGunData(_miniGun));
    }
}
