using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommonEnemy : Enemy
{

    [SerializeField] TextMeshPro _damageTextMesh;
    [SerializeField] protected int _startDamage;
    protected int _damage;
    
    private new void Awake()
    {
        base.Awake();
        CardGameController.EnemyTurnEvent.AddListener(attack);
        _damage = _startDamage - CardGameController.Instance.Player.Arrmor;
        _damageTextMesh.text = "" + _damage;
        CardGameController.Instance.Player.ChangingArrmorEvent.AddListener(damageChange);
    }
    public void damageChange(int x)
    {
        _damage -= x;
        _damageTextMesh.text = "" + _damage;
    }
    public virtual void attack()
    {
        CardGameController.Instance.Player.TakeDamage(_damage);
    }
}