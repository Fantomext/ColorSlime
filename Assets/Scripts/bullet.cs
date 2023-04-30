using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    MainColorManager mainColor;

    [SerializeField] private float _bulletPower = 10f;


    void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(transform.right * Random.Range(250, 500));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent<Slime>(out var slime))
        {
            Color colorSlime = slime.GetComponentInChildren<SpriteRenderer>().color;
            if (true ) // “”“ Œ—“¿ÕŒ¬»À—ﬂ.
             {

            }
           
            slime.GetComponentInChildren<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
            slime.GetComponent<Rigidbody2D>().AddForce(transform.right * _bulletPower);
        }
        Destroy(gameObject);
    }
}


   
