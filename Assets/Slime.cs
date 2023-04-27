using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Collider2D _slimeColider;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _slimeColider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Vector2 toPlayer = _player.position - transform.position;
        Debug.Log(toPlayer.normalized);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
        {
            Physics2D.IgnoreCollision(_slimeColider, collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
