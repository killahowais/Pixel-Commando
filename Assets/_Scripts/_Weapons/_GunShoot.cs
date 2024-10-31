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
 
    public void Update()
    {

    }

    public void Shoot()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(_shootPos.position, _shootPos.right);

        if (hit.collider)
        {
            IDamageable damageable = hit.collider.GetComponent(typeof(IDamageable)) as IDamageable;
            if (damageable != null)
            {
                Debug.Log("Hit an object that implements IDamageable");
            }
        }



        Debug.DrawRay(_shootPos.position, _shootPos.right * 15, Color.magenta);
        Debug.Log("Shooting");
    }
}
