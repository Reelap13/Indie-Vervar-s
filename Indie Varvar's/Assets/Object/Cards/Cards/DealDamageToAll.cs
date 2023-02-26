using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToAll : Card, IPlayableCard
{
    [SerializeField] int _damage;
    public void OnPlay()
    {
        List<EnemyCash> enemyList = CardGameController.Instance.EnemyBoard.EnemyList;
        int n = enemyList.Count;
        int i = 0;
        while (i < n)
        {
            enemyList[i].Enemy.takeDamage(_damage + CardGameController.Instance.Player.Strenght);
            while (n > enemyList.Count)
            {
                --n;
                --i;
            }
            ++i;
        }
    }
}
