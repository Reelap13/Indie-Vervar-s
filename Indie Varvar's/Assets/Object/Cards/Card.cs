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

    private bool isMoveAnim = false;
    public void MoveToPosition(Vector3 position, Quaternion rotation, StateCard state = StateCard.IN_GAME)
    {
        if (isMoveAnim)
            StopCoroutine("MoveToPositionAnim");
        _state = state;
        StartCoroutine(MoveToPositionAnim(position, rotation));
    }
    private IEnumerator MoveToPositionAnim(Vector3 position, Quaternion rotation)
    {
        isMoveAnim = true;

        Vector3 startPosition = _transform.position;
        Quaternion startRotation = _transform.rotation;
        float t = 0;

        const float animationDuration = 1f;

        while (t < 1)
        {
            _transform.position = Vector3.Lerp(startPosition, position, t * t);
            _transform.rotation = Quaternion.Lerp(startRotation, rotation, t * t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        isMoveAnim = false;
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


