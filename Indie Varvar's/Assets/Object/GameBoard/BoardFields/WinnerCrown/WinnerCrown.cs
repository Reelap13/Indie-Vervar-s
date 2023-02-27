using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCrown : Field
{
    public override void OnStep()
    {
        CardGameController.Instance.Player.SaveHP();
        Debug.Log("Win!");
    }
}
