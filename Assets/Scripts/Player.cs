using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpPower = 15f;
    [SerializeField] private bool _facingRight = false;
    [SerializeField] private float _friction = 1f;
    [SerializeField] private float _frictionStopSpeed = 5f;
    [SerializeField] private float _frictionWalkSpeed = 1f;
    [SerializeField] private FixedJoystick _fixedJoystickMove;
    [SerializeField] private bool _isWalking = false;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        float horiozntal = _fixedJoystickMove.Horizontal;
        float vertical = _fixedJoystickMove.Vertical;

        _rigidbody2D.AddForce(new Vector2(horiozntal, vertical).normalized * _speed);

        if (horiozntal != 0 || vertical != 0)
        {
            _isWalking = true;
            _friction = _frictionWalkSpeed;
        }
        else
        {
            _isWalking = false;
            _friction = _frictionStopSpeed;
        }

        _rigidbody2D.AddForce(new Vector2(-_rigidbody2D.velocity.x * _friction, -_rigidbody2D.velocity.y * _friction));

        
    }
    
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }

    private void FlipRotate()
    {
        Vector3 currentRotate = gameObject.transform.localEulerAngles;
        currentRotate.y += 180;
        gameObject.transform.localEulerAngles = currentRotate;

        _facingRight = !_facingRight;
    }

    public void Die()
    {
        _rigidbody2D.mass = 1000f;
        _rigidbody2D.velocity = Vector3.zero;
        
        
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}
