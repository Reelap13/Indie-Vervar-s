using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int hp;
    protected virtual void OnDestroy()
    {
        CardGameController.Instance.EnemyBoard.RemoveEnemy(this);
    }


    bool isMoveAnim;
    public virtual void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this);
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
