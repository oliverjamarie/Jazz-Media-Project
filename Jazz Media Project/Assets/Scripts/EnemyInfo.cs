using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    public Text health, defence;
    string baseHealthStr, baseDefenceStr;
    public BattleManager battleManager;
    Unit unit;
 
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unit == null)
        {
            unit = battleManager.enemyUnit;
        }

        health.text = baseHealthStr + "\n" + unit.currHP + "/" + unit.maxHP + "HP";
        defence.text = baseDefenceStr + "\n" + unit.defense;
    }
}
