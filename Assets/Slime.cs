using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Collider2D _slimeColider;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _player;
    [SerializeField] private bool _facingRight;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _slimeColider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Vector2 toPlayer = _player.position - transform.position;
     

        _rigidbody2D.velocity = new Vector2(toPlayer.x, toPlayer.y);

        if (toPlayer.x < 0 && _facingRight == false)
        {
            FlipRotate();
        }
        if (toPlayer.x > 0 && _facingRight == true)
        {
            FlipRotate();
        }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponentInChildren<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
        {
            Physics2D.IgnoreCollision(_slimeColider, collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
