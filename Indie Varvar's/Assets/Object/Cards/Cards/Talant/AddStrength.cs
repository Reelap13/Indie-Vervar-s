using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStrength : Card, IPlayableCard
{
    public void OnPlay()
    {
        CardGameController.Instance.Player.Strength += 1;
        CardGameController.Instance.Hand.DeleteCard(this);
    }
}
