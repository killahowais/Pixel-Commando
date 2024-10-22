using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GunShoot : MonoBehaviour
{
    // gun data
    [SerializeField] _GunData _gunData;
    [SerializeField] Transform _shootPos;
 
    public void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(_shootPos.position, _shootPos.right);
        Debug.DrawRay(_shootPos.position, _shootPos.right*15, Color.magenta);
    }

    IEnumerator FireGun ()
    { 



        return null;
    } 
}
