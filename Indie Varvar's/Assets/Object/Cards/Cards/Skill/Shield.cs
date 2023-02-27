using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Card, IPlayableCard
{
    [SerializeField] int _shield;
    public void OnPlay()
    {
        CardGameController.Instance.Player.Shield += _shield;
    }
}
