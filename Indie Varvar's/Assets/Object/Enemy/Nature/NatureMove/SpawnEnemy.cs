using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : NatuerMove
{
    [SerializeField] Enemy _enemy;
    override public void DoMove() 
    {
        CardGameController.Instance.EnemyBoard.AddEnemy(_enemy.gameObject);
    }
}
