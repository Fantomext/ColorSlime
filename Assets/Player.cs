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

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horiozntal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _rigidbody2D.AddForce(new Vector2(horiozntal, vertical).normalized * _speed);


        _rigidbody2D.AddForce(new Vector2(-_rigidbody2D.velocity.x * _friction, -_rigidbody2D.velocity.y * _friction));

        if (horiozntal > 0 && _facingRight)
        {
            Flip();
        }
        if (horiozntal < 0 && _facingRight == false)
        {
            Flip();
        }
    }
    
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color color = collision.gameObject.GetComponent<SpriteRenderer>().color;
        Debug.Log(color);
    }
}
