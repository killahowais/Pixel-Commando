using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Player;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpingPower;

    private bool _moveLeft = false; 
    private bool _moveRight = false;
    private bool _isGrounded = true;
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
    public void GroundCheck() 
    {
     RaycastHit hit;
     // if(Physics.Raycast(Player.transform.)

    }

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
