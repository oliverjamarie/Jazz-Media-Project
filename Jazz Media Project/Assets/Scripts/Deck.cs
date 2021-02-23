using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour 
{
    public List<GameObject> cards = new List<GameObject>();
    Stack<GameObject> deck = new Stack<GameObject>();
    Stack<GameObject> discardPile = new Stack<GameObject>();

    public int maxLength;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gameObject in cards)
        {
            if (gameObject.GetComponent<CardInterface>() == null)
            {
                throw new System.NotImplementedException();
            }
        }

        initDeck();
    }

    public GameObject dealCard()
    {
        GameObject card = deck.Pop();
        discardPile.Push(card);

        return card;
    }

    public GameObject[] dealCards(int numCards)
    {
        List<GameObject> dealtCards = new List<GameObject>();

        for (int i = 0; i < numCards; i++)
        {
            dealtCards.Add(dealCard());
        }

        return dealtCards.ToArray();
    }

    // Initialises the deck stack by inserting all cards in a random order
    void initDeck()
    {
        List<GameObject> cardsCopy = new List<GameObject>(cards);

        for (int i = 0; i < cards.Count; i++)
        {
            int randIndex = (int)(Random.value * 100) % cardsCopy.Count;

            deck.Push(cardsCopy[randIndex]);

            cardsCopy.RemoveAt(randIndex);
        }
    }

    // reinserts the discard pile into the deck and shuffles the deck
    // Can't use initDeck() function because we need to take into account the
    // player's cards in hand
    public void shuffle()
    {
        List<GameObject> cardsToShuffle = new List<GameObject>();
        cardsToShuffle.AddRange(deck);
        cardsToShuffle.AddRange(discardPile);

        deck.Clear();
        discardPile.Clear();

        int size = cardsToShuffle.Count;

        for (int i = 0; i < size; i++)
        {
            int randIndex = (int)(Random.value * 100) % cardsToShuffle.Count;

            deck.Push(cardsToShuffle[randIndex]);

            cardsToShuffle.RemoveAt(randIndex);
        }
    }

    public bool discardCard(GameObject card)
    {
        if (card.GetComponent<CardInterface>() == null)
            return false;

        discardPile.Push(card);

        return true;
    }


    // returns the card on the top of the deck
    public GameObject getNextCard()
    {
        return deck.Peek();
    }
}
