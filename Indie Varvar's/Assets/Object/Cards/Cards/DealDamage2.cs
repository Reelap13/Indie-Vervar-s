using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage2 : Card, IPlayableCard
{
    public void OnPlay()
    {
        CardGameController.Instance.EnemyBoard.DealDamageToFirstEnemy(2);
    }
}
