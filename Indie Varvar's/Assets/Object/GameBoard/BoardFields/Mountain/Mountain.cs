using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : Field
{
    public override void OnStep()
    {
        CardGameController.Instance.Player.Arrmor++;
        CardGameController.Instance.Player.Strength--;
        Debug.Log("new armor: " + CardGameController.Instance.Player.Arrmor);
    }
    public override void OnUnstep()
    {
        CardGameController.Instance.Player.Arrmor--;
        CardGameController.Instance.Player.Strength++;
    }
}
