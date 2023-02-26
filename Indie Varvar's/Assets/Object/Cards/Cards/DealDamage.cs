using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : Card, IPlayableCard
{
    [SerializeField] int _damage;
    public void OnPlay()
    {
        CardGameController.Instance.EnemyBoard.DealDamageToFirstEnemy(_damage + CardGameController.Instance.Player.Strenght);
    }
}
