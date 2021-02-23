using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicDefend : MonoBehaviour, CardInterface
{
    public int defenseValue, cost = 1;
    public Text cardTitle, cardDesc;
    BattleManager battleManager;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GetComponent<BasicCardInfo>().battleManager;
    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.defense += defenseValue + playedBy.defenseModifier;
    }

    public Text getCardTitle()
    {
        return cardTitle;
    }

    public Text getCardDesc()
    {
        return cardDesc;
    }

    public int getCardCost()
    {
        return cost;
    }
}
