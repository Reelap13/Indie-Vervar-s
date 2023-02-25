using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckController : MonoBehaviour
{
    [SerializeField] private GameObject _cardPref;

    private List<CardCash> _playableDeck = new List<CardCash>();
    private List<CardCash> _discardDeck = new List<CardCash>();

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
        return topCard;
    }

    public void AddDiscardedCard(CardCash card)
    {
        _discardDeck.Add(card);
        //карту нужно сделать не активной
    }

    private void ResetDeck()
    {
        foreach (CardCash card in _discardDeck)
        {
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
        for (int i = 0; i < 20; ++i)
        {
            _playableDeck.Add(CreateCard(_cardPref));
        }
    }

    private CardCash CreateCard(GameObject cardPref)
    {
        GameObject newCard = Instantiate(cardPref) as GameObject;
        CardCash cardCash = new CardCash(newCard);

        cardCash.Transform.parent = _transform;
        cardCash.Transform.position = _transform.position;

        return cardCash;
    }
}

public struct CardCash
{
    public GameObject CardObject;
    public Transform Transform;
    public Card Card;
    public Renderer Renderer;

    public CardCash(GameObject cardPref)
    {
        CardObject = cardPref;
        Transform = cardPref.GetComponent<Transform>();
        Card = cardPref.GetComponent<Card>();
        Renderer = cardPref.GetComponent<Renderer>();
    }
}
