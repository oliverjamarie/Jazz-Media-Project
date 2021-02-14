using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TauntCard : MonoBehaviour, CardInterface
{
    BattleManager battleManager;
    public int cost;
    public Text cardDesc, cardTitle;

    void Start()
    {
        battleManager = GetComponent<BasicCardInfo>().battleManager;
    }

    public void effect()
    {
        Unit player = battleManager.playerUnit;

        player.maxNumMoves++;

        player.numMovesRemaining -= cost;
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
