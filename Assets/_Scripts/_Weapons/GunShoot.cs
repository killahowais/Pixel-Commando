using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public interface IDamageable
{
    public void Damage(float damageAmount) 
    {
    

    }
}
public class GunShoot : MonoBehaviour
{
    // Scripts 
    [SerializeField] private Animations Animations;
    [SerializeField] private _PlayerMovement playerMovement;

    // Data
    public string GunName;
    public int CurrentAmmo;
    public int MaxAmmo;
    public int Damage;
    public float ShootCoolDown;
    public float ReloadTime;
    public float ShootingRange = 15f;


    private bool _isShooting = false;
    private bool _isReloading = false;
    private bool _isShootingCoroutineRunning = false;

    [SerializeField] private TextMeshProUGUI _currentAmmoText;
    [SerializeField] Transform _shootPos;
    [SerializeField] SpriteRenderer _gunSprite;



    private void Update()
    {
        _currentAmmoText.text = "Current Ammo: " + CurrentAmmo.ToString();
    }

    // function for the button to call this coroutine
    public void StartShooting()
    {
        _isShooting = true;
        if (!_isShootingCoroutineRunning)
        {
            StartCoroutine(Shoot());
        }
    }
    // stop shooting
    public void StopShooting() 
    {
        _isShooting = false;
        Animations.IdleAnimation();
    }

    // shoot logic
    IEnumerator Shoot() 
    {
        _isShootingCoroutineRunning = true;

        while (_isShooting)
        {
            if (CurrentAmmo != 0 && !_isReloading)
            {

                RaycastHit2D hit = Physics2D.Raycast(_shootPos.position, _shootPos.right, 15f);
                Debug.DrawRay(_shootPos.position, _shootPos.right * 15, Color.magenta);
                CurrentAmmo--;
                Animations.ShootAnimation(GunName);
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
        Animations.IdleAnimation();
        _isShootingCoroutineRunning = false;
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
    // update for the button to call reload coroutine
    public void Reload() 
    {
        StartCoroutine(ReloadGun());
    }
}
