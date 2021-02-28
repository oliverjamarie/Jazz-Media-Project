using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicDefend : MonoBehaviour, CardInterface
{
    public int defenseValue;
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
        playedBy.defense += defenseValue + playedBy.defensePts;
    }

    public Text getCardTitle()
    {
        return cardInfo.cardTitle;
    }

    public Text getCardDesc()
    {
        return cardInfo.cardDesc;
    }

    public int getCardCost()
    {
        return cardInfo.cardCost;
    }
}
