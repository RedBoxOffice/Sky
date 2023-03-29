using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HashAnimationsName))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _acceleration = 0.1f;
    private float _startSpeed = 0f;
    private bool _isClickButtonA = false;
    private bool _isClickButtonD = false;  
    private HashAnimationsName _animationsName;

    private void Start()
    {
        _animationsName = GetComponent<HashAnimationsName>();
    }

    void Update()
    {
        transform.Translate(0, 0, _startSpeed * Time.deltaTime, Space.Self);
        MoveHero();
    }

    private void MoveHero()
    {
        if (Input.GetKeyDown(KeyCode.A) && _isClickButtonA == false)
        {
            if (_startSpeed == 0f)
            {
                _animator.CrossFade(_animationsName.RunningHash, 0.1f);
                _startSpeed = 1f;
            }

            _startSpeed += _acceleration;
            _isClickButtonA = true;
            _isClickButtonD = false;
        }  
        else if (Input.GetKeyDown(KeyCode.D) && _isClickButtonD == false)
        {
            if (_startSpeed == 0f)
            {
                _animator.CrossFade(_animationsName.RunningHash, 0.1f);
                _startSpeed = 1f;
            }

            _startSpeed += _acceleration;
            _isClickButtonD = true;
            _isClickButtonA = false;
        }
    }
}
