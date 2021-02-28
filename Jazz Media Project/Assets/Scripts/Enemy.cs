using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    BattleManager battleManager;
    public int maxHandSize, currHandSize, startHandSize;
    public Text nextMove;
    Deck deck;
    Unit unit;


    // Start is called before the first frame update
    void Start()
    {
        deck = GetComponent<Deck>();
        unit = GetComponent<Unit>();
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();
    }

    public void enemyPlay()
    {

        GameObject card = deck.dealCard();
        GameObject cardGO = Instantiate(card);

        cardGO.GetComponent<CardInterface>().effect(unit, battleManager.playerUnit);
        Destroy(cardGO);
    }

    public GameObject getNextMove()
    {
        return deck.getNextCard();
    }
}
