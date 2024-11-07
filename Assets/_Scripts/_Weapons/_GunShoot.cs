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
    // gun data
    [SerializeField] _GunData _gunData;
    [SerializeField] Transform _shootPos;
    [SerializeField] SpriteRenderer _gunSprite;

    [SerializeField] float _shootCoolDown;

    private float damageAmount;

    public void Update()
    {
        // cool of for shooting
        _shootCoolDown = _shootCoolDown-Time.deltaTime;
        if (_shootCoolDown < 0)
        {
            _shootCoolDown = 0;
        }


    }
        public void Shoot()
        {
        if (_shootCoolDown == 0)
        {
            _shootCoolDown = +0.2f;
            RaycastHit2D hit = Physics2D.Raycast(_shootPos.position, _shootPos.right, 15f);
            Debug.DrawRay(_shootPos.position, _shootPos.right * 15, Color.magenta);

            if (hit.collider != null)
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.Damage(damageAmount); // Breng schade toe aan het object
                }
            }
            else
            {
                Debug.Log("Niets geraakt");
            }
            Debug.Log(hit.collider.name);
        }
       }
 }
