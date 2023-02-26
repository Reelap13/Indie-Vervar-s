using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] TextMeshPro _hpTextMesh;
    [SerializeField] int _hp;
    protected virtual void OnDestroy()
    {
        CardGameController.Instance.EnemyBoard.RemoveEnemy(this);
    }


    bool isMoveAnim;
    private void Start()
    {
        _hpTextMesh.text = "" + _hp;
    }
    public virtual void takeDamage(int damage)
    {
        _hp -= damage;
        _hpTextMesh.text = "" + _hp;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void MoveToPosition(Vector3 position)
    {
        if (isMoveAnim)
            StopCoroutine("MoveToPositionAnim");

        StartCoroutine(MoveToPositionAnim(position));
    }

    private IEnumerator MoveToPositionAnim(Vector3 position)
    {
        isMoveAnim = true;

        Transform enemy = GetComponent<Transform>();
        Vector3 startPosition = enemy.position;
        float t = 0;

        const float animationDuration = 1f;

        while (t < 1)
        {
            enemy.position = Vector3.Lerp(startPosition, position, t * t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        isMoveAnim = false;
    }
}
