using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _basicSpeed;
    [SerializeField] private float _rotationSpeed;
    private Rigidbody _rigidbody;
    private float _xDirection;
    private float _zDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetDirection();
    }

    private void FixedUpdate()
    {
        Move();
        SetRotation();
    }

    private void GetDirection()
    {
        _zDirection = Input.GetAxis("Vertical");
        _xDirection = Input.GetAxis("Horizontal");
    }

    private void SetRotation()
    {
        
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_xDirection, 0, _zDirection).normalized * _basicSpeed;
    }
}
