using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : Field
{
    public override void OnStep()
    {
        CardGameController.Instance.Player.Arrmor++;
        CardGameController.Instance.Player.Strength--;
    }
    public override void OnUnstep()
    {
        CardGameController.Instance.Player.Arrmor--;
        CardGameController.Instance.Player.Strength++;
    }
}
