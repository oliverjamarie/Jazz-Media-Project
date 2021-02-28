using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttack : MonoBehaviour, CardInterface
{
    public int damage;
    BasicCardInfo cardInfo;
    BattleManager battleManager;
    
    
    private void Start()
    {
        cardInfo = GetComponent<BasicCardInfo>();
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();

    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.attack(target, damage);
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
