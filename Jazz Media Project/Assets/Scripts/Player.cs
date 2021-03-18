using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    BattleManager battleManager;
    public GameObject hand;
    Unit unit;
    Deck deck;
    public int maxHandSize, initialHandSize;
    int currHandSize;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        deck = GetComponent<Deck>();

        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();

        if (deck == null)
        {
            throw new System.NotSupportedException();
        }

        currHandSize = initialHandSize;

        Card[] cards = deck.dealCards(initialHandSize);
        
        foreach (Card card in cards)
        {
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

        if (currHandSize <= 0 && battleManager.gameState == BattleState.Player_Turn)
        {
            Card card = deck.dealCard();
            Instantiate(card, hand.transform);
            currHandSize++;
        }
    }

    public void DealCard()
    {
        if (currHandSize <= maxHandSize && unit.numMovesRemaining > 0
            && battleManager.gameState == BattleState.Player_Turn)
        {
            Card card = deck.dealCard();
            Instantiate(card, hand.transform);
            currHandSize++;
            unit.numMovesRemaining--;
        }
    }

    public bool playCard(GameObject cardGO)
    {
        Card card = cardGO.GetComponent<Card>();

        if (unit.numMovesRemaining - card.cost < 0)
            return false;

        card.effect(unit, battleManager.enemyUnit);

        unit.numMovesRemaining -= card.cost;

        currHandSize -=1 ;

        deck.discardCard(card);

        return true;
    }

    public int getCurrHandSize()
    {
        return currHandSize;
    }
}
