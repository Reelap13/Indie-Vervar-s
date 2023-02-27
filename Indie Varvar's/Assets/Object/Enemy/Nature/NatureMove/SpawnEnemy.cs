using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : NatuerMove
{
    [SerializeField] List<Enemy> _enemys;
    override public void DoMove() 
    {
        for (int i = 0; i < _enemys.Count; i++)
        {
            CardGameController.Instance.EnemyBoard.AddEnemy(_enemys[i].gameObject);
        }
    }
}
