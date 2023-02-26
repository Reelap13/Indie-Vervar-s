using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    private const int MAX_NUMBER_OF_CARDS = 8;
    private const int STARTING_NUMBER_OF_CARDS = 8;
    private const float DELAY_BETWEEN_ACTION = 0.1f;

    private Vector3 RAISING_ACTIVE_CARD = new Vector3(0, 10f, -4f);
    private const float SCALE_ACTIVE_CARD = 2f;

    private List<CardCash> _hand = new List<CardCash>();
    private DeckController _deck;
    private Transform _transform;

    private void Awake()
    {
        _deck = CardGameController.Instance.Deck;
        _transform = GetComponent<Transform>();

        CardGameController.SuperStartTurnEvent.AddListener(TakeHand);
        CardGameController.SuperFinishTurnEvent.AddListener(DiscardHand);

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
                PlaceCardInHand();
                break;
            }
        }
    }

    public void DiscardCard(CardCash cardCash)
    {
        HideActiveCard(cardCash.Card);
        _hand.Remove(cardCash);
        _deck.AddDiscardedCard(cardCash);
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
        PlaceCardInHand();
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


    private void PlaceCardInHand()
    {
        if (_hand.Count == 0)
            return;

        const float PROXIMITY = 0.8f;
        const float DROPPING = 0.03f;
        const float ANGLE_ROTATION = 3;

        Vector3 size = _hand[0].Renderer.bounds.size;
        Vector3 sizeByX = new Vector3(size.x, 0, 0);
        Vector3 sizeByY = new Vector3(0, size.y, 0);
        Vector3 sizeByZ = new Vector3(0, 0, 1f);

        Vector3 startPos = _transform.position - _hand.Count * sizeByX / 2.0f * PROXIMITY;

        for(int i = 0; i < _hand.Count; ++i)
        {
            CardCash cardCash = _hand[i];
            float angleOfRotate = ((float)(_hand.Count - 1) / 2.0f - (float)i) * ANGLE_ROTATION;
            Vector3 position = startPos + sizeByX * i * PROXIMITY 
                                        - sizeByY * DROPPING * Mathf.Pow(Mathf.Abs((float)(_hand.Count - 1) / 2.0f - (float)i), 1.5f)
                                        - sizeByZ * i;

            Quaternion rotation = Quaternion.Euler(0, 0, angleOfRotate);

            cardCash.Card.MoveToPosition(position, rotation);
        }
    }


    public void ShowActiveCard(Card card)
    {
        if (card.IsActive)
            return;

        card.IsActive = true;
        CardCash newActiveCard = FindActiveCard(card);

        newActiveCard.Transform.localScale *= SCALE_ACTIVE_CARD;
        newActiveCard.Transform.position += RAISING_ACTIVE_CARD;
    }

    public void HideActiveCard(Card card)
    {
        if (!card.IsActive)
            return;


        card.IsActive = false;
        CardCash newPassiveCard = FindActiveCard(card);

        newPassiveCard.Transform.localScale /= SCALE_ACTIVE_CARD;
        newPassiveCard.Transform.position -= RAISING_ACTIVE_CARD;
    }

    private CardCash FindActiveCard(Card card)
    {
        foreach(CardCash cardCash in _hand)
        {
            if (cardCash.Card.Equals(card))
            {
                return cardCash;
            }
        }

        return new CardCash();
    }


}
