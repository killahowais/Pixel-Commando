using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class _PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Player;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpingPower;

    private bool _moveLeft = false; 
    private bool _moveRight = false;
    private bool _isGrounded = false;
    private bool _jump = false;

    private void Update()
    {
        // move left
        if (_moveLeft)
        {
            Player.transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        }
        // move right
        if (_moveRight)
        {
            Player.transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
        }
        Debug.Log(_isGrounded);
        Debug.DrawRay(Player.transform.position, Vector2.down * 0.6f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(Player.transform.position, Vector2.down, 2f);
        if (hit.collider != null) //&& hit.collider.CompareTag("Ground")) //&& hit.collider.CompareTag("Ground"))
        {
            if (hit.collider.CompareTag("Ground"))
            {

                Debug.Log("Player is on the ground");
                _isGrounded = true;
            }
        }
        else
        {
            _isGrounded = false;
        }


    }
    // fixedupdate used for consistent output not dependent on fps
    private void FixedUpdate()
    {
        if (_jump && _isGrounded)
        {
            Player.AddForce(transform.up * _jumpingPower, ForceMode2D.Impulse);
            _jump = false;
        }
    }
    // checking if player is on the ground 
    //private void GroundCheck() 
    //{
    //    // Cast a ray downwards to check if the player is on the ground
    //    RaycastHit2D hit = Physics2D.Raycast(Player.transform.position, Vector2.down, 2f);

    //    // Check if the ray hit something and if the hit object has the "Ground" tag
    //    if (hit.collider != null && hit.collider.CompareTag("Ground"))
    //    {
    //        Debug.Log("Player is on the ground");
    //        return true;
    //    }

    //    // If no ground detected, return false
    //    return false;
    //}

    // Jump
    public void Jump() 
    {
      _jump = true;
    }

    // trigger for start moving right
    public void MoveRight()
    {
        _moveRight = true;
    }
    // trigger for stop moving right
    public void StopMoveRight()
    {
        _moveRight = false;
    }
    // trigger for start moving left 
    public void MoveLeft()
    {
        _moveLeft = true;
    }
    // trigger for stop moving left
    public void StopMoveLeft()
    {
        _moveLeft = false;
    }
}
