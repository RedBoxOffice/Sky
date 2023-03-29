using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffects : MonoBehaviour
{   
    [SerializeField] private float _upSpeedLimit;
    [SerializeField] private float _upSpeed;
    [SerializeField] private float _density;
    [SerializeField] private Animator _animator;
    [SerializeField] private HashAnimationsName _animationsName;

    private float _timeChangeAnimation = 0.1f;
    private float _drag = 0.99f;
    private float _angularDrag = 0.8f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _animator.CrossFade(_animationsName.TreadingWater, _timeChangeAnimation);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player) && other.TryGetComponent(out Rigidbody rigidbody))
        {            
            float difference = (transform.position.y - other.transform.position.y) * _upSpeed;
            rigidbody.AddForce(new Vector3(0f, Mathf.Clamp(Mathf.Abs(Physics.gravity.y) * difference, 0, Mathf.Abs(Physics.gravity.y) * _upSpeedLimit), 0f), ForceMode.Acceleration);
            rigidbody.drag = _drag;
            rigidbody.angularDrag = _angularDrag;           
        }         
    }
}
