using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreparedAttackCard : MonoBehaviour, CardInterface
{

    public int modifier = 1; 
    BattleManager battleManager;
    BasicCardInfo cardInfo;

    // Start is called before the first frame update
    void Start()
    {
        cardInfo = GetComponent<BasicCardInfo>();
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();
    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.attackPts += modifier;
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
