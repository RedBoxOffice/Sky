using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private HashAnimationsName _animationsName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Flying flying) && other.TryGetComponent(out Rigidbody rigidbody))
        {
            flying.enabled = false;
            rigidbody.useGravity = true;
            _animator.CrossFade(_animationsName.FallingHash, 0.1f);
        }
    }
}
