using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    public Text health, numMoves, defence, attPts, defPts;
    string baseHealthStr, baseNumMovesStr , baseDefenceStr, baseAttPtsStr, baseDefPtsStr;
    BattleManager battleManager;
    Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();

        unit = battleManager.playerUnit;

        baseHealthStr = health.text;
        baseNumMovesStr = numMoves.text;
        baseDefenceStr = defence.text;
        baseAttPtsStr = attPts.text;
        baseDefPtsStr = defPts.text;

        if (unit != null)
        {
            health.text = baseHealthStr +"\n" + unit.currHP + "/" + unit.maxHP + "HP";
            numMoves.text = baseNumMovesStr + "\n" + unit.numMovesRemaining + "/" + unit.maxNumMoves;
            defence.text = baseDefenceStr + "\n" + unit.defense;
        }
        
    }

    // Update is called once per frame
    void Update()
    {    
        if (unit == null)
        {
            unit = battleManager.playerUnit;
        }

        if (battleManager.gameState == BattleState.Lost)
        {
            enabled = false;
            return;
        }

        health.text = baseHealthStr + "\n" + unit.currHP + "/" + unit.maxHP + "HP";
        numMoves.text = baseNumMovesStr + "\n" + unit.numMovesRemaining + "/" + unit.maxNumMoves;
        defence.text = baseDefenceStr + "\n" + unit.defense;
        attPts.text = baseAttPtsStr + "\n" + unit.attackPts;
        defPts.text = baseDefPtsStr + "\n" + unit.defensePts;
    }
}
