using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndDealDamage : Card, IPlayableCard
{
    [SerializeField] int _damage;
    public void OnPlay()
    {
        CardGameController.Instance.Player.Move(-1);
        CardGameController.Instance.EnemyBoard.DealDamageToFirstEnemy(_damage + CardGameController.Instance.Player.Strength);
    }
}
