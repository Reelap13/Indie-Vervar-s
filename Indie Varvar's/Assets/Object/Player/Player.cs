using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Player : MonoBehaviour
{
    private const int STARTING_MANA_VALUE = 10;
    private const int STARTING_HP_VALUE = 3;

    private int _healthPoint;
    private int _mana;
    private int _shield;

    public UnityEvent<int> ChangingHPEvent = new UnityEvent<int>();
    public UnityEvent<int> ChangingManaEvent = new UnityEvent<int>();
    public UnityEvent<int> ChangingShieldEvent = new UnityEvent<int>();
    public UnityEvent Dying = new UnityEvent();

    private void Awake()
    {
        CardGameController.SuperStartTurnEvent.AddListener(ResetShield);
        CardGameController.SuperStartTurnEvent.AddListener(ResetMana);
        HP = STARTING_HP_VALUE;
    }

    public void TakeDamage(int value)
    {
        if (Shield > 0)
        {
            value -= Shield;
            Shield = Mathf.Max(0, -value);
        }

        if (value < 0)
        {
            return;
        }

        if (HP - value <= 0)
        {
            HP = 0;
            Dying.Invoke();
            return;
        }

        HP -= value;
        ChangingHPEvent.Invoke(_healthPoint);
    }

    

    public int HP
    {
        private set 
        { 
            if (value <= 0)
            {
                Dying.Invoke();
            }

            _healthPoint = value;
            ChangingHPEvent.Invoke(_healthPoint);
        }
        get
        {
            return _healthPoint;
        }
    }

    public int Mana
    {
        set
        {
            if (value < 0)
            {
                //Exception
            }

            _mana = value;
            ChangingManaEvent.Invoke(_mana);
        }
        get
        {
            return _mana;
        }
    }

    public int Shield
    {
        set
        {
            _shield = value;
            ChangingShieldEvent.Invoke(_shield);
        }
        get
        {
            return _shield;
        }
    }

    public void ResetShield()
    {
        Shield = 0;
    }

    public void ResetMana()
    {
        Mana = STARTING_MANA_VALUE;
    }

    public void Move(int x)
    {
        CardGameController.Instance.GameBoard.Move(x);
    }

}
