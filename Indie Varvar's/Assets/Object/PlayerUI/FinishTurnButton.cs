using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTurnButton : MonoBehaviour
{
    public void FinishTurn()
    {
        if (CardGameController.Instance.Phase == TurnPhase.PLAYER_TURN)
        { 
            CardGameController.Instance.FinishTurn();
        }
    }
}
