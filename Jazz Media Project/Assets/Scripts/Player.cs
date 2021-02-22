using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BattleManager battleManager;
    public GameObject hand;
    Unit unit;
    Deck deck;
    public int maxHandSize, currHandSize;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();

        deck = GetComponent<Deck>();

        if (deck == null)
        {
            throw new System.NotSupportedException();
        }

        currHandSize = 5;

        GameObject[] cards = deck.dealCards(5);

        foreach (GameObject card in cards)
        {
            card.GetComponent<BasicCardInfo>().battleManager = battleManager;
            Instantiate(card, hand.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (battleManager == null)
        {
            print("BattleManager is NULL");
        }

        if (currHandSize == 0 && battleManager.gameState == BattleState.Player_Turn)
        {
            GameObject card = deck.dealCard();
            card.GetComponent<BasicCardInfo>().battleManager = battleManager;
            Instantiate(card, hand.transform);
            currHandSize++;
        }
    }

    public void DealCard()
    {
        if (currHandSize <= maxHandSize && unit.numMovesRemaining > 0
            && battleManager.gameState == BattleState.Player_Turn)
        {
            GameObject card = deck.dealCard();
            card.GetComponent<BasicCardInfo>().battleManager = battleManager;
            Instantiate(card, hand.transform);
            currHandSize++;
            unit.numMovesRemaining--;
        }
    }

    public bool playCard(GameObject card)
    {

        CardInterface cardComponent = card.GetComponent<CardInterface>();

        if (cardComponent == null)
            return false;

        cardComponent.effect();

        currHandSize--;

        deck.discardCard(card);

        return true;
    }
}
