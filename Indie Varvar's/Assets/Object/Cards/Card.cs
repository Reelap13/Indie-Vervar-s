using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Card : MonoBehaviour
{
    [SerializeField] string _description;
    [SerializeField] protected int _mana;
    [SerializeField] TextMeshPro _manaTextMesh;


    private StateCard _state;
    private Transform _transform;
    private bool _isActive = false;
    private SideCard _side;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _state = StateCard.IN_DECK;
        _side = SideCard.BACK;
        _transform.rotation = Quaternion.Euler(180, 180, 0);
        //_manaTextMesh.text = "" + _mana;
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
            StopAllCoroutines();
            //StopCoroutine("MoveToPositionAnim");
        if (state == StateCard.IN_DECK)
            _state = state;
        StartCoroutine(MoveToPositionAnim(position, rotation, state));
    }
    private IEnumerator MoveToPositionAnim(Vector3 position, Quaternion rotation, StateCard state)
    {
        isMoveAnim = true;

        Vector3 startPosition = _transform.position;
        Quaternion startRotation = _transform.rotation;
        Quaternion finalRotation = GetAngle(rotation);
        float t = 0;

        const float animationDuration = 1f;

        while (t < 1)
        {
            _transform.position = Vector3.Lerp(startPosition, position, t * t);
            _transform.rotation = Quaternion.Lerp(startRotation, finalRotation, t * t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        _state = state;
        isMoveAnim = false;
    }

    public void MoveToPositionWithoutAnim(Vector3 position, Quaternion rotation, StateCard state = StateCard.IN_GAME)
    {
        _transform.position = position;
        _transform.rotation = GetAngle(rotation);
        _state = state;
    }

    public void MoveToPositionWithRotationSide(Vector3 position, Quaternion rotation, StateCard state = StateCard.IN_GAME)
    {
        if (isMoveAnim)
            StopAllCoroutines();
            //StopCoroutine("MoveToPositionAnim");
        if (state == StateCard.IN_DECK)
            _state = state;
        ChagneSideWithoutRotation();
        StartCoroutine(MoveToPositionAnim(position, rotation, state));
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

    private Quaternion GetAngle(Quaternion rotation)
    {
        Vector3 frontSide = new Vector3(180, 0, 0);
        Vector3 backSide = new Vector3(180, 180, 0);

        if (_side == SideCard.FRONT)
        {
            return Quaternion.Euler(rotation.eulerAngles + frontSide);
        }
        else
        {
            return Quaternion.Euler(rotation.eulerAngles + backSide);
        }
    }

    public void ChagneSide()
    {
        Vector3 frontSide = new Vector3(0, 0, 0);
        Vector3 backSide = new Vector3(0, 180, 0);

        if (_side == SideCard.FRONT)
        {
            _side = SideCard.BACK;
            _transform.rotation = Quaternion.Euler(_transform.rotation.eulerAngles + frontSide - backSide);
        }
        else
        {
            _side = SideCard.FRONT;
            _transform.rotation = Quaternion.Euler(_transform.rotation.eulerAngles - frontSide + backSide);
        }
    }

    private void ChagneSideWithoutRotation()
    {
        if (_side == SideCard.FRONT)
        {
            _side = SideCard.BACK;
        }
        else
        {
            _side = SideCard.FRONT;
        }
    }
}

public enum StateCard
{
    IN_GAME,
    IN_DECK
};


public enum SideCard
{
    BACK,
    FRONT
}