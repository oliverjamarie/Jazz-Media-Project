using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttack : MonoBehaviour, CardInterface
{
    public int damage = 1;
    public int cost = 1;
    BattleManager battleManager;
    public Text cardTitle, cardDesc;

    private void Start()
    {
        battleManager = GetComponent<BasicCardInfo>().battleManager;
    }

    public void effect()
    {
        battleManager.playerUnit.attack(battleManager.enemyUnit, damage);
        battleManager.playerUnit.numMovesRemaining -= cost;
    }

    public Text getCardTitle()
    {
        print(cardTitle.text);
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
