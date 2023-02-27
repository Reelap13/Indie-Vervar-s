using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckController : MonoBehaviour
{
    [SerializeField] private GameObject _cardPref;
    [SerializeField] private DeckSaver _saver;

    private List<CardCash> _playableDeck = new List<CardCash>();
    private List<CardCash> _discardDeck = new List<CardCash>();
    private Vector3 INDENT_OF_DISCARD_DECK = new Vector3(1, 0, 0) * 1f;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        LoadDeck();
    }

    public CardCash TakeCard()
    {
        if (_playableDeck.Count == 0)
        {
            ResetDeck();
        }

        CardCash topCard = _playableDeck[0];
        _playableDeck.RemoveAt(0);
        //topCard.Card.ChagneSide();
        return topCard;
    }

    public void AddDiscardedCard(CardCash cardCash)
    {
        _discardDeck.Add(cardCash);

        cardCash.Transform.parent = _transform;
        //Debug.Log(cardCash.BoxCollider.bounds.size.x);
        cardCash.Card.MoveToPositionWithRotationSide(_transform.position + cardCash.BoxCollider.bounds.size.x * INDENT_OF_DISCARD_DECK, _transform.rotation, StateCard.IN_DECK);
    }

    private void ResetDeck()
    {
        foreach (CardCash card in _discardDeck)
        {
            card.Card.MoveToPosition(_transform.position, _transform.rotation, StateCard.IN_DECK);
            _playableDeck.Add(card);
        }
        _discardDeck.Clear();

        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < _playableDeck.Count; ++i)
        {
            int rnd = UnityEngine.Random.Range(0, _playableDeck.Count - 1);
            CardCash temp = _playableDeck[rnd];
            _playableDeck[rnd] = _playableDeck[i];
            _playableDeck[i] = temp;
        }
    }

    private void LoadDeck()
    {
        List<GameObject> cardPrefs = _saver.LoadDeck();

        foreach(GameObject cardPref in cardPrefs)
        {
            _playableDeck.Add(CreateCard(cardPref));
        }
    }

    private CardCash CreateCard(GameObject cardPref)
    {
        GameObject newCard = Instantiate(cardPref) as GameObject;
        CardCash cardCash = new CardCash(newCard);

        cardCash.Transform.parent = _transform;
        cardCash.Card.MoveToPositionWithoutAnim(_transform.position, _transform.rotation, StateCard.IN_DECK);

        return cardCash;
    }
}

public struct CardCash
{
    public GameObject CardObject;
    public Transform Transform;
    public Card Card;
    public Renderer Renderer;
    public BoxCollider BoxCollider;

    public CardCash(GameObject cardPref)
    {
        CardObject = cardPref;
        Transform = cardPref.GetComponent<Transform>();
        Card = cardPref.GetComponent<Card>();
        Renderer = cardPref.GetComponent<Renderer>();
        BoxCollider = cardPref.GetComponent<BoxCollider>();
    }
}
