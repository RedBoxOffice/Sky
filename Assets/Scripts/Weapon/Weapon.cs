using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _aimCamera;
    [SerializeField] private float _damage;
    [SerializeField] private float _range;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {       
        RaycastHit hit;

        if (Physics.Raycast(_aimCamera.transform.position, _aimCamera.transform.forward, out hit, _range))
        {            
            _audioSource.Play();
            RocksOfShoot enemy = hit.transform.GetComponent<RocksOfShoot>();
            enemy.TakeDamage(_damage);            
        }
        else
        {
            _audioSource.Play();
        }
        
    }
}
