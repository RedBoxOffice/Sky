using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AimCamera : MonoBehaviour
{    
    [SerializeField] private float _sensivity;

    private float _xRotation;
    private float _yRotation;
    private float _xRotationCurrent;
    private float _yRotationCurrent;
    private float _smoothTime = 0.1f;
    private float _currentVelocityX;
    private float _currentVelocityY;
    private Camera _aimCamera;

    private void Start()
    {
        _aimCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        _xRotation += Input.GetAxis("Mouse X") * _sensivity;
        _yRotation += Input.GetAxis("Mouse Y") * _sensivity;
        _xRotationCurrent = Mathf.SmoothDamp(_xRotation, _xRotationCurrent, ref _currentVelocityX, _smoothTime);
        _yRotationCurrent = Mathf.SmoothDamp(_yRotation, _yRotationCurrent, ref _currentVelocityY, _smoothTime);
        _aimCamera.transform.rotation = Quaternion.Euler(-(_yRotationCurrent), _xRotationCurrent, 0f);        
    }
}
