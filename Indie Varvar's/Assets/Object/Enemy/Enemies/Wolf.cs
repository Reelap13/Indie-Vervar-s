using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : CommonEnemy
{
    public override void attack()
    {
        base.attack();
        damageChange(-1);
    }
}
