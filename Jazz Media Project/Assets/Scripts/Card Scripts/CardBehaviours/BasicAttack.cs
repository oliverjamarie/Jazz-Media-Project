using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttack : MonoBehaviour, CardInterface
{
    public int damage;
    public int cost;
    BattleManager battleManager;
    public Text cardTitle, cardDesc;

    private void Start()
    {
        battleManager = GetComponent<BasicCardInfo>().battleManager;
    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.attack(target, damage);
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
