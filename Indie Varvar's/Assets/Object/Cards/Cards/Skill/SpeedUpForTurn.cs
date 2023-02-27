using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpForTurn : Card, IPlayableCard
{
    public void OnPlay()
    {
        CardGameController.Instance.Player.Speed *= 2;
        CardGameController.AfterEnemyTurnEvent.AddListener(OnNewTurn);
    }
    private void OnNewTurn()
    {
        CardGameController.Instance.Player.Speed /= 2;

        CardGameController.AfterEnemyTurnEvent.RemoveListener(OnNewTurn);

    }
}
