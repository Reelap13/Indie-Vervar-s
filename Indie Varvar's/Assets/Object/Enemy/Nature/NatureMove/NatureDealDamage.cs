using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureDealDamage : NatuerMove
{
    [SerializeField] int _damage;
    [SerializeField] int _hitCount;
    public override void DoMove()
    {
        for (int i = 0; i < _hitCount; i++)
        {
            CardGameController.Instance.Player.TakeDamage(_damage);
        }
    }
}
