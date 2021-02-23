using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreparedAttackCard : MonoBehaviour, CardInterface
{
    BattleManager battleManager;
    public int cost = 1;
    public Text title, description;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GetComponent<BasicCardInfo>().battleManager;
    }

    public void effect(Unit playedBy, Unit target)
    {
        playedBy.attackPts++;
    }

    public int getCardCost()
    {
        return cost;
    }

    public Text getCardDesc()
    {
        return description;
    }

    public Text getCardTitle()
    {
        return title;
    }

    
}
