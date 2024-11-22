using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void Damage(float damageAmount) 
    {
    

    }
}
public class _GunShoot : MonoBehaviour
{

    [SerializeField] private string GunName;
    [SerializeField] private int CurrentAmmo;
    [SerializeField] private int MaxAmmo;
    [SerializeField] private int Damage;
    [SerializeField] private float ShootCoolDown;
    [SerializeField] private float ReloadTime;
    [SerializeField] private float ShootingRange = 15f;


    [SerializeField] private bool _isShooting = false;
    [SerializeField] private bool _isReloading = false;
  
    public void StartShooting()
    {
        _isShooting = true;
        if (_isShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    public void StopShooting() 
    {
      _isShooting =false;
    }

    IEnumerator Shoot() 
    {

        while (_isShooting)
        {
            if (CurrentAmmo != 0 && !_isReloading)
            {
                RaycastHit2D hit = Physics2D.Raycast(_shootPos.position, _shootPos.right, 15f);
                Debug.DrawRay(_shootPos.position, _shootPos.right * 15, Color.magenta);
                CurrentAmmo--;
                if (hit.collider != null)
                {
                    IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.Damage(Damage); // Damage the object 
                    }
                }
                else
                {
                    Debug.Log("Niets geraakt");
                }

            }
            yield return new WaitForSeconds(ShootCoolDown);
        }
        yield return null;
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

    // reload data
    IEnumerator ReloadGun()
    {
        if (CurrentAmmo!=MaxAmmo)
        {
            _isReloading = true;
            yield return new WaitForSeconds(ReloadTime);
            CurrentAmmo = MaxAmmo;
            _isReloading = false;
        }
        yield return null;
    }

    public void Reload() 
    {
        StartCoroutine(ReloadGun());
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
