using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield2 : Card, IPlayableCard
{
    public void OnPlay()
    {
        CardGameController.Instance.Player.Shield += 2;
    }
}
