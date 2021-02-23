using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingCard : MonoBehaviour, CardInterface
{
    public Text cardTitle, cardDesc;
    public int cost, healAmt;
    BattleManager battleManager;


    // Start is called before the first frame update
    void Start()
    {
        battleManager = GetComponent<BasicCardInfo>().battleManager;
    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.currHP += healAmt;

        if (playedBy.currHP > playedBy.maxHP)
            playedBy.currHP = playedBy.maxHP;
    }

    public int getCardCost()
    {
        return cost;
    }

    public Text getCardDesc()
    {
        return cardDesc;
    }

    public Text getCardTitle()
    {
        return cardTitle;
    }

    
}
