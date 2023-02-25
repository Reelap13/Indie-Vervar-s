using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckController : MonoBehaviour
{
    private List<Card> _playableDeck = new List<Card>();
    private List<Card> _discardDeck = new List<Card>();

    private void Awake()
    {
        LoadDeck();
    }

    public Card TakeCard()
    {
        if (_playableDeck.Count == 0)
        {
            ShuffleDeck();
        }

        Card topCard = _playableDeck[0];
        _playableDeck.RemoveAt(0);
        return topCard;
    }

    public void DiscardCard(Card card)
    {
        _discardDeck.Add(card);
    }

    private void ResetDeck()
    {
        foreach (Card card in _discardDeck)
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
            Card temp = _playableDeck[rnd];
            _playableDeck[rnd] = _playableDeck[i];
            _playableDeck[i] = temp;
        }
    }

    private void LoadDeck()
    {

    }
}
