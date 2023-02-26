using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Card, IPlayableCard
{
    [SerializeField] int _distance;
    public void OnPlay()
    {
        CardGameController.Instance.Player.Move(_distance);

    }
}
