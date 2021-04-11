using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject handTransform;
    public int maxHandSize, initialHandSize;
    public List<Card> hand;

    int currHandSize;
    BattleManager battleManager;
    Unit unit;
    Deck deck;
    


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

        hand = new List<Card>(deck.dealCards(initialHandSize));

        string cardTag;

        if (tag == "Champion")
        {
            cardTag = "ChampCard";
            handTransform = GameObject.FindGameObjectWithTag("AlternateHand");
        }
        else
        {
            cardTag = "PlayerCard";
            handTransform = GameObject.FindGameObjectWithTag("Hand");
        }
            

        foreach(Card card in hand)
        {
            card.transform.SetParent(handTransform.transform);
            card.tag = cardTag;
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
            Instantiate(card, handTransform.transform);
            currHandSize++;
        }
    }

    public void DealCard()
    {
        if (currHandSize <= maxHandSize && unit.numMovesRemaining > 0
            && battleManager.gameState == BattleState.Player_Turn)
        {
            deck.dealCard().transform.SetParent(handTransform.transform);

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
