using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void RunAnimation()
    {
        _animator.SetTrigger("Run");
    }
    public void IdleAnimation()
    {
        _animator.SetTrigger("Idle");
    }

    // Setting the trigger deppending on the name 
    public void ShootAnimation(string GunType)
    {
        _animator.SetTrigger(GunType);
    }
}
