using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : Singleton<CameraController>
{
    private Transform _point;
    private Transform _cameraTransform;
    private bool _isAnimation;

    private void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
        _isAnimation = false;
    }

    

    public void ChangePoint(Transform point)
    {
        StopAllCoroutines();
        _point = point;
        StartCoroutine(MoveToPoint(_point, _point));
    }

    private IEnumerator MoveToPoint(Transform position, Transform rotation)
    {
        _isAnimation = true;

        Vector3 startPosition = _cameraTransform.position;
        const float animationDuration = 1f;

        float t = 0;
        while (t < 1)
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, position.position, t);
            _cameraTransform.rotation = Quaternion.Lerp(transform.rotation, rotation.rotation, t);

            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        _isAnimation = false;
    }
}


