using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    private const int MAX_NUMBER_OF_CARDS = 8;
    private const int STARTING_NUMBER_OF_CARDS = 5;
    private const float DELAY_BETWEEN_ACTION = 0.1f;

    private List<CardCash> _hand = new List<CardCash>();
    private DeckController _deck;
    private Transform _transform;

    private void Awake()
    {
        _deck = CardGameController.Instance.Deck;
        _transform = GetComponent<Transform>();

        Debug.Log(1);
        CardGameController.StartTurnEvent.AddListener(TakeHand);
        CardGameController.FinishTurnEvent.AddListener(DiscardHand);

    }

    public void TakeCards(int n = 1)
    {
        StartCoroutine(TakeCardsWithDelay(n));
    }
    private void TakeHand()
    {
        StartCoroutine(TakeCardsWithDelay(STARTING_NUMBER_OF_CARDS));
    }

    public void DiscardCard(Card card)
    {
        foreach(CardCash cardCash in _hand)
        {
            if (cardCash.Card.Equals(card))
            {
                _hand.Remove(cardCash);
                _deck.AddDiscardedCard(cardCash);
            }
        }
    }

    public void DiscardCard(CardCash card)
    {
        _hand.Remove(card);
        _deck.AddDiscardedCard(card);
    }

    private void DiscardHand()
    {
        StartCoroutine(DiscardCardsWithDelay());
    }

    private IEnumerator TakeCardsWithDelay(int n)
    {
        for (int i = 0; i < n; ++i)
        {
            TakeCard();
            yield return new WaitForSeconds(DELAY_BETWEEN_ACTION);
        }
    }
    private void TakeCard()
    {
        if (_hand.Count < MAX_NUMBER_OF_CARDS)
        {
            CardCash cardCash = _deck.TakeCard();
            cardCash.Transform.parent = _transform;
            _hand.Add(cardCash);
        }
    }

    private IEnumerator DiscardCardsWithDelay()
    {
        while (_hand.Count != 0)
        {
            DiscardCard(_hand[0]);
            yield return new WaitForSeconds(DELAY_BETWEEN_ACTION);
        }
    }

}
