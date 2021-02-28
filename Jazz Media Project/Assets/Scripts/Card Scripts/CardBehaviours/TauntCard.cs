using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TauntCard : MonoBehaviour, CardInterface
{
    BasicCardInfo cardInfo;
    BattleManager battleManager;

    void Start()
    {
        cardInfo = GetComponent<BasicCardInfo>();
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();

        if (cardInfo == null)
            print("card is NULL");
    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.maxNumMoves++;
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
