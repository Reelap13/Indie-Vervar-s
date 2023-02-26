using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [SerializeField] protected int _mana;

    private StateCard _state;
    private Transform _transform;
    private bool _isActive = false;
    

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _state = StateCard.IN_DECK;
    }

    private void OnMouseDown()
    {
        if (_state == StateCard.IN_GAME)
        {
            if (this is IPlayableCard)
            {
                CardGameController.Instance.Hand.HideActiveCard(this);
                if (CardGameController.Instance.Player.Mana < _mana)
                {
                    return;
                }
                CardGameController.Instance.Player.Mana = CardGameController.Instance.Player.Mana - _mana;
                ((IPlayableCard)this).OnPlay();
                CardGameController.Instance.Hand.DiscardCard(this);
            }
        }
    }

    private void OnMouseEnter()
    {
        if (_state == StateCard.IN_GAME)
        {
            CardGameController.Instance.Hand.ShowActiveCard(this);
        }
    }

    private void OnMouseExit()
    {
        if (_state == StateCard.IN_GAME)
        {
            CardGameController.Instance.Hand.HideActiveCard(this);
        }
    }

    public void MoveToPosition(Vector3 position, Quaternion rotation, StateCard state = StateCard.IN_GAME)
    {
        _transform.position = position;
        _transform.rotation = rotation;
        _state = state;
    }

    public bool IsActive
    {
        set
        {
            _isActive = value;
        }
        get
        {
            return _isActive;
        }
    }

}

public enum StateCard
{
    IN_GAME,
    IN_DECK
};


