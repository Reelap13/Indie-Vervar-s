using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field : MonoBehaviour
{
    private bool _isMoveAnim = false;
    private bool _isRemoveAnim = false;
    private Vector3 _removeIndent = new Vector3(-20, 0, 0);
    public void Remove()
    {
        StopAllCoroutines();
        StartCoroutine(RemoveAnim());
    }

    public void MoveToPosition(Vector3 position)
    {
        if (_isRemoveAnim)
            return;
        if (_isMoveAnim)
            StopAllCoroutines();
        StartCoroutine(MoveToPositionAnim(position));
    }

    private IEnumerator RemoveAnim()
    {
        _isRemoveAnim = true;

        Transform field = GetComponent<Transform>();
        Vector3 startPosition = field.position;
        Vector3 finalPosition = field.position + _removeIndent;
        float t = 0;

        const float animationDuration = 1f;

        while (t < 1)
        {
            field.position = Vector3.Lerp(startPosition, finalPosition, t * t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }
        Destroy(gameObject);
    }

    private IEnumerator MoveToPositionAnim(Vector3 position)
    {
        _isMoveAnim = true;

        Transform field = GetComponent<Transform>();
        Vector3 startPosition = field.position;
        float t = 0;

        const float animationDuration = 1f;

        while (t < 1)
        {
            field.position = Vector3.Lerp(startPosition, position, t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        _isMoveAnim = false;
    }

    public virtual void OnStep()
    {

    }
    public virtual void OnUnstep()
    {

    }
}
