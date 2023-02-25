using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField] private DeckController _deck;
    private const int MAX_NUMBER_OF_CARDS = 8;
    private const int STARTING_NUMBER_OF_CARDS = 5;
    private const float DELAY_BETWEEN_ACTION = 0.1f;
    private List<Card> _hand = new List<Card>();



    private void Awake()
    {
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
        _hand.Remove(card);
        _deck.AddDiscardedCard(card);
    }

    private void DiscardHand()
    {
        StartCoroutine(DiscardCardsWithDelay());
    }

    private void TakeCard()
    {
        if (_hand.Count < MAX_NUMBER_OF_CARDS)
        {
            _hand.Add(_deck.TakeCard());
        }
    }

    private IEnumerator TakeCardsWithDelay(int n)
    {
        for (int i = 0; i < n; ++i)
        {
            TakeCard();
            yield return new WaitForSeconds(DELAY_BETWEEN_ACTION);
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
