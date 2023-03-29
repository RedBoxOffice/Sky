using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RocksOfShoot : Enemy
{
    private float _health = 5f;
    private float _timeDelay = 3f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            _rigidbody.useGravity = true;
            Invoke(nameof(Die), _timeDelay);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
