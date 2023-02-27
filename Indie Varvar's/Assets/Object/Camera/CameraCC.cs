using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCC : MonoBehaviour
{
    [SerializeField] private Transform point;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.position = point.position;
        _transform.rotation = point.rotation;
    }
}
