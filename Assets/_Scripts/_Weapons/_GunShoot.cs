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
    // Guns
    [SerializeField] _GunData _ak47;
    [SerializeField] _GunData _pistol;
    [SerializeField] _GunData _miniGun;
    [SerializeField] _GunData _currentGunData;
    // gun data
    [SerializeField] Transform _shootPos;
    [SerializeField] SpriteRenderer _gunSprite;

    [SerializeField] private string GunName;
    [SerializeField] private int CurrentAmmo;
    [SerializeField] private int MaxAmmo;
    [SerializeField] private int Damage;
    [SerializeField] private float ShootCoolDown;
    [SerializeField] private float ReloadTime;
    [SerializeField] private float ShootingRange = 15f;

    private void Start()
    {
       SetGunData(_ak47);   
    }

    // switch from gun data 
    //public void SetGunData(_GunData newGunData)
    //{
    //    _currentGunData = newGunData;

    //    GunName = _currentGunData._gunName;
    //    CurrentAmmo = _currentGunData._currentAmmo;
    //    MaxAmmo = _currentGunData._maxAmmo;
    //    Damage = _currentGunData._damage;
    //    ShootCoolDown = _currentGunData._shootCoolDown;
    //    ReloadTime = _currentGunData._reloadTime;
    //    ShootingRange = _currentGunData._shootingRange;


    //    //_currentGunData._gunName = GunName ;
    //    //_currentGunData._shootCoolDown = ShootCoolDown ;
    //    //_currentGunData._shootingRange = ShootingRange ;
    //    //_currentGunData._currentAmmo = CurrentAmmo ;
    //    //_currentGunData._maxAmmo = MaxAmmo ;
    //    //_currentGunData._damage = Damage ;    
    //    //_currentGunData._reloadTime = ReloadTime ;  

    //}

    public void Update()
    {
        // cool of for shooting
        ShootCoolDown = ShootCoolDown -Time.deltaTime;
        if (ShootCoolDown < 0)
        {
            ShootCoolDown = 0;
        }
        // Debug.Log(CurrentAmmo);

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

        CurrentAmmo= MaxAmmo;


        return null;
    }


    public void Shoot()
        {
        if (CurrentAmmo!= 0 && ShootCoolDown == 0)
        {
            ShootCoolDown = +0.2f;
            RaycastHit2D hit = Physics2D.Raycast(_shootPos.position, _shootPos.right, 15f);
            Debug.DrawRay(_shootPos.position, _shootPos.right * 15, Color.magenta);
            CurrentAmmo--;
            if (hit.collider != null)
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.Damage(Damage); // Breng schade toe aan het object
                }
            }
            else
            {
                Debug.Log("Niets geraakt");
            }
            
        }
       }
 }
