using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingCard : MonoBehaviour, CardInterface
{
    public int healAmt;
    BasicCardInfo cardInfo;
    BattleManager battleManager;


    // Start is called before the first frame update
    void Start()
    {
        cardInfo = GetComponent<BasicCardInfo>();
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();

        if (cardInfo == null)
            print("card is NULL");
    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.currHP += healAmt;

        if (playedBy.currHP > playedBy.maxHP)
            playedBy.currHP = playedBy.maxHP;
    }

    public int getCardCost()
    {
        return cardInfo.cardCost;
    }

    public Text getCardDesc()
    {
        return cardInfo.cardDesc;
    }

    public Text getCardTitle()
    {
        return cardInfo.cardTitle;
    }

    
}
