using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class _EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private GameObject PlayerOffset;
    [SerializeField] private bool _attack;
    private float _chaseSpeed;

    private void Update()
    {
        PlayerOffset.transform.position += new Vector3(Random.Range(1f, 3f),0,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        return null;
    }
}