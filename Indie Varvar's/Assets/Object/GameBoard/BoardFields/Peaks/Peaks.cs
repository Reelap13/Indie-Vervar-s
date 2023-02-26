using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peaks : Field
{
    override public void OnStep()
    {
        CardGameController.Instance.Player.TakeDamage(1);
    }
}
