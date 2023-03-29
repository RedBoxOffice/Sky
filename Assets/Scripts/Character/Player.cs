using UnityEngine;

[RequireComponent(typeof(Flying))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(HashAnimationsName))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
 
    private Flying _flying;
    private Movement _movement;    
    private HashAnimationsName _animationsName;
    private CapsuleCollider _capsuleCollider;
    private float _colliderPositionX = -0.07f;
    private float _colliderPositionY = 1.19f;
    private float _colliderPositionZ = 0.9f;
    private int _axis = 2;
    private float _timeChangeAnimation = 0.8f;

    void Start()
    {        
        _flying = GetComponent<Flying>();
        _movement = GetComponent<Movement>();       
        _animationsName = GetComponent<HashAnimationsName>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent(out StartPlatform startPlatform))
        {            
            _flying.enabled = false;
        }          
    }   

    private void OnCollisionExit(Collision collision)
    {        
        _movement.enabled = false;
        _flying.enabled = true;
        _capsuleCollider.center = new Vector3(_colliderPositionX, _colliderPositionY, _colliderPositionZ);
        _capsuleCollider.direction = _axis;
        _animator.CrossFade(_animationsName.FlyingHash, _timeChangeAnimation);
    }    
}
