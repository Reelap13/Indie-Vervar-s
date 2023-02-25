using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : Enemy
{
    [SerializeField] private int _damage;
    private void Awake()
    {
        CardGameController.EnemyTurnEvent.AddListener(attack);
    }
    public virtual void attack()
    {
        CardGameController.Instance.Player.TakeDamage(_damage);
    }
}