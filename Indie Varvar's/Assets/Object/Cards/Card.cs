using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] protected int _mana;

    private StateCard _state;


    private void ChangeState(StateCard state)
    {
        _state = state;
        switch (_state)
        {
            case StateCard.ACTIVE:

                break;
            case StateCard.PASIVE:

                break;
            case StateCard.IN_DECK:

                break;
            case StateCard.NOT_PLAYABLE:

                break;
        }
    }

    private void OnMouseDown()
    {
        if (_state == StateCard.ACTIVE)
        {

        }
    }

    private void OnMouseEnter()
    {
        if (_state == StateCard.PASIVE)
        {
            ChangeState(StateCard.ACTIVE);
        }
    }

}

enum StateCard
{
    ACTIVE,
    PASIVE,
    IN_DECK,
    NOT_PLAYABLE
};
