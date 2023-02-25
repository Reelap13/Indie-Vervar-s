using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Player : MonoBehaviour
{
    private int _healthPoint;
    private int _mana;
    private int _shield;

    public UnityEvent<int> ChangingHPEvent = new UnityEvent<int>();
    public UnityEvent<int> ChangingManaEvent = new UnityEvent<int>();
    public UnityEvent Dying = new UnityEvent();

    private void Start()
    {
        SetHP(10);
        SetMana(15); 
    }

    public void TakeDamage(int value)
    {


        if (_shield > 0)
        {
            value -= _shield;
            _shield = Mathf.Max(0, -value);
        }

        _healthPoint -= value;
        if (_healthPoint <= 0)
        {
            Dying.Invoke();
            return;
        }

        ChangingHPEvent.Invoke(_healthPoint);
    }

    public void SetHP(int healthPoint)
    {
        if (healthPoint <= 0)
        {
            //Exception
        }

        _healthPoint = healthPoint;
        ChangingHPEvent.Invoke(_healthPoint);
    }

    public void SpendMana(int value)
    {
        if (_mana - value < 0)
        {
            //Exception
        }

        _mana -= value;
        ChangingManaEvent.Invoke(_mana);
    }

    public void SetMana(int mana)
    {
        if (mana < 0)
        {
            //Exception
        }

        _mana = mana;
        ChangingManaEvent.Invoke(_mana);
    }

    public void AddShield(int shieldPoint)
    {
        _shield += shieldPoint;
    }

    public void ResetShield()
    {
        _shield = 0;
    }

    public void Move(int x)
    {
        Debug.Log("Move: " + x + " он кста не реализован");
    }

}
