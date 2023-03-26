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
        _capsuleCollider.center = new Vector3(-0.07f, 1.19f, 0.9f);
        _capsuleCollider.direction = 2;
        _animator.CrossFade(_animationsName.FlyingHash, 0.8f);
    }    
}
