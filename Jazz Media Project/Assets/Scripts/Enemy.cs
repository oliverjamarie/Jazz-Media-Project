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
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        deck = GetComponent<Deck>();
        unit = GetComponent<Unit>();
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();
        animator = GetComponent<Animator>();
    }

    public void enemyPlay()
    {
        StartCoroutine(wait());
        Card card = deck.dealCard();

        card.effect(unit, battleManager.playerUnit);
        deck.discardCard(card);
        print(card.name);

        animator.SetTrigger("Attack");

        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }

    public Card getNextMove()
    {
        return deck.getNextCard();
    }
}
