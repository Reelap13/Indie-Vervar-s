using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : Card, IPlayableCard
{
    public void OnPlay()
    {
        CardGameController.Instance.Player.Move(1);

    }
}
