using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageMulSpeed : Card, IPlayableCard
{
    [SerializeField] int _damage;
    public void OnPlay()
    {
        CardGameController.Instance.EnemyBoard.DealDamageToFirstEnemy(
            (int)((_damage + CardGameController.Instance.Player.Strength) *
            CardGameController.Instance.Player.Speed));
    }
}
