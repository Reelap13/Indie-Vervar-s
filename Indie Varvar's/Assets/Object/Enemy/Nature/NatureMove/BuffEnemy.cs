using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEnemy : NatuerMove
{
    [SerializeField] int _hpBuff;
    public override void DoMove()
    {
        List<EnemyCash> enemyList = CardGameController.Instance.EnemyBoard.EnemyList;
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].Enemy.takeDamage(-_hpBuff);
        }
    }
}
