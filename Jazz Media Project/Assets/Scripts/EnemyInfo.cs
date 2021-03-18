using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    public Text health, defence, nextMoveOutput, attPts, defPts, numMoves;
    string baseHealthStr, baseDefenceStr, baseAttPtsStr, baseDefPtsStr, baseNumMovesStr;
    BattleManager battleManager;
    Unit unit;
    Enemy enemy;
 
    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();

        unit = battleManager.enemyUnit;

        baseHealthStr = health.text;
        baseDefenceStr = defence.text;
        baseAttPtsStr = attPts.text;
        baseDefPtsStr = defPts.text;
        baseNumMovesStr = numMoves.text;

        if (unit != null)
        {
            health.text = baseHealthStr + "\n" + unit.currHP + "/" + unit.maxHP + "HP";
            defence.text = baseDefenceStr + "\n" + unit.defense;
        }

        if (battleManager.enemyGO != null)
            enemy = battleManager.enemyGO.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (battleManager.gameState == BattleState.Won)
        {
            enabled = false;
            return;
        }

        if (unit == null)
        {
            unit = battleManager.enemyUnit;
        }

        if (enemy == null)
        {
            enemy = battleManager.enemyGO.GetComponent<Enemy>();
        }

        health.text = baseHealthStr + "\n" + unit.currHP + "/" + unit.maxHP + "HP";
        defence.text = baseDefenceStr + "\n" + unit.defense;
        attPts.text = baseAttPtsStr + "\n" + unit.attackPts;
        defPts.text = baseDefPtsStr + "\n" + unit.defensePts;
        numMoves.text = baseNumMovesStr + "\n" + unit.maxNumMoves;


        nextMoveOutput.text = enemy.getNextMove().GetComponent<Card>().cardTitle;
    }
}
