using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksOfShoot : Enemy
{
    private float _health = 5f;    

    public void TakeDamage(float amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            _rigidbody.useGravity = true;
            Invoke(nameof(Die), 3f);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
