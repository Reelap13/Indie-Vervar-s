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
    private int _strength = 0;
    private int _arrmor = 0;
    private float _speed = 1;

    public UnityEvent<int> ChangingHPEvent = new UnityEvent<int>();
    public UnityEvent<int> ChangingManaEvent = new UnityEvent<int>();
    public UnityEvent<int> ChangingShieldEvent = new UnityEvent<int>();
    public UnityEvent<int> ChangingStrenghtEvent = new UnityEvent<int>();
    public UnityEvent<int> ChangingArrmorEvent = new UnityEvent<int>();
    public UnityEvent<float> ChangingSpeedEvent = new UnityEvent<float>();
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
    public int Strength
    {
        set
        {
            ChangingStrenghtEvent.Invoke(value - _strength);
            _strength = value;
        }
        get
        {
            return _strength;
        }
    }
    public int Arrmor
    {
        set
        {
            ChangingArrmorEvent.Invoke(value - _arrmor);
            _arrmor = value;
        }
        get
        {
            return _arrmor;
        }
    }
    public float Speed
    {
        set
        {
            _speed = value;
            ChangingSpeedEvent.Invoke(_speed);
        }
        get
        {
            return _speed;
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
            if (_shield < 0)
            {
                _shield = 0;
            }
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
        if (Mathf.Abs(x * _speed + 0.01f) < 1)
        {
            if (x < 0)
            {
                CardGameController.Instance.GameBoard.Move(-1);
            }
            else
            {
                CardGameController.Instance.GameBoard.Move(1);
            }
            return;
        }
        CardGameController.Instance.GameBoard.Move((int)(x * _speed + 0.01f));
    }

}
