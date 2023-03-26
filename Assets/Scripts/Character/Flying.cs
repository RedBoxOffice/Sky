using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Flying : MonoBehaviour
{
    [SerializeField] private float _moveAxisX;
    [SerializeField] private float _moveAxisY;
    [SerializeField] private float _staticSpeedFlying;
    [SerializeField] private float _turnSmoothTime;
    [SerializeField] private Transform _camera;

    private float _turnSmoothVelocity;
    private float _smoothVelocityZ;
    private bool _isChangeController = false;
    private float _timeForceFly;

    void Update()
    {        
        ControllerFlying();

        if (_isChangeController == false)
        {
            DoStaticFly();
        }
        else
        {
            ChangeFlying();
        }
        
    }

    private void ControllerFlying()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 direction = new Vector3(0, 0, 1).normalized;

            if (direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);                 
            }
        }

        if (Input.GetKey(KeyCode.A))
        {            
            transform.Translate(-_moveAxisX * Time.deltaTime, 0, 0, Space.Self);            
        }        
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_moveAxisX * Time.deltaTime, 0, 0, Space.Self);            
        }          
    }

    private void DoStaticFly()
    {
        transform.Translate(0, -_moveAxisY * Time.deltaTime, _staticSpeedFlying * Time.deltaTime, Space.Self);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fuel fuel))
        {            
            _isChangeController = true;
        }        
    }

    private void ChangeFlying()
    {
        _timeForceFly += Time.deltaTime;
        
        if (_timeForceFly <= 5)
        {
            transform.Translate(0, _moveAxisY * Time.deltaTime, _staticSpeedFlying * Time.deltaTime, Space.Self);            
        }
        else if (_timeForceFly <= 25)
        {
            transform.Translate(0, 0, _staticSpeedFlying * Time.deltaTime, Space.Self);
        }
        else
        {
            _isChangeController = false;
            _timeForceFly = 0;
        }        
    }       
}
