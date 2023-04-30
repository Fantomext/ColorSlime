using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private float _pushPower = 15f;
    [SerializeField] private float _multiPower = 4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.TryGetComponent<PlayerHealth>(out var player))
        {
            player.TakeDamage(_damageValue);
            player.GetComponent<Rigidbody2D>().AddForce(transform.right * _pushPower);
            gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * (_pushPower * _multiPower));
        }
    }
}
