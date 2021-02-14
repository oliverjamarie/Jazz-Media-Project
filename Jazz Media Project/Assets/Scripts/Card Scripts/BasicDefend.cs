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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void effect()
    {
        Unit player = battleManager.playerUnit;

        player.defense = defenseValue;

        player.numMovesRemaining -= cost;
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
