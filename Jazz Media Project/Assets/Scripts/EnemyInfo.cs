using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    public Text health, defence, nextMoveOutput;
    string baseHealthStr, baseDefenceStr;
    public BattleManager battleManager;
    Unit unit;
    Enemy enemy;
 
    // Start is called before the first frame update
    void Start()
    {
        unit = battleManager.enemyUnit;


        baseHealthStr = health.text;
        baseDefenceStr = defence.text;

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
        nextMoveOutput.text = enemy.getNextMove().GetComponent<CardInterface>().getCardTitle().text;
    }
}
