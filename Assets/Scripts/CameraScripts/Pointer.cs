using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Transform _pointer;
    [SerializeField] private float _defaultDistance;
    private float _rayLength;

    private void Start()
    {
        _rayLength = _defaultDistance;
    }

    private void Update()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.magenta);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (_rayLength > hit.distance)
            {
                _rayLength = hit.distance;
            }
        }
        else
        {
            _rayLength = _defaultDistance;
        }
        
        Vector3 point = ray.GetPoint(_rayLength);
        _pointer.position = point;
    }
}
