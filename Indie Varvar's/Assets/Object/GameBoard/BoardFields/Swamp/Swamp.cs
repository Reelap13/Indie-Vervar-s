using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : Field
{
    public override void OnStep()
    {
        CardGameController.Instance.Player.Speed /= 2;
    }
    public override void OnUnstep()
    {
        CardGameController.Instance.Player.Speed *= 2;
    }
}
