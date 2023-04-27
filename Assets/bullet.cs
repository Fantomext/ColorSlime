using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    
    
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(transform.right * Random.Range(150, 300));
        _rigidbody2D.AddForce(transform.up * Random.Range(150, 300));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Slime>(out var slime))
        {
            collision.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
        }
        Destroy(gameObject);
    }
}
