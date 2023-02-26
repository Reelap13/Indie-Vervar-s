using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field : MonoBehaviour
{
    private bool isMoveAnim = false;
    private Vector3 removeIndent = new Vector3(0, 0, 0);
    public void Remove()
    {
        StartCoroutine(RemoveAnim());
    }

    public void MoveToPosition(Vector3 position)
    {
        if (isMoveAnim)
            StopCoroutine("MoveToPositionAnim");
        StartCoroutine(MoveToPositionAnim(position));
    }

    private IEnumerator RemoveAnim()
    {
        Transform field = GetComponent<Transform>();
        Vector3 startPosition = field.position;
        Vector3 finalPosition = field.position + removeIndent;
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
        isMoveAnim = true;

        Transform field = GetComponent<Transform>();
        Vector3 startPosition = field.position;
        float t = 0;

        const float animationDuration = 1f;

        while (t < 1)
        {
            field.position = Vector3.Lerp(startPosition, position, t * t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        isMoveAnim = false;
    }

    public virtual void OnStep()
    {

    }
    public virtual void OnUnstep()
    {

    }

}
