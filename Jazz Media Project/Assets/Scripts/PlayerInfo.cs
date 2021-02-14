using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    public Text health, numMoves, defence;
    string baseHealthStr, baseNumMovesStr , baseDefenceStr;
    public BattleManager battleManager;
    Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        unit = battleManager.playerUnit;
        baseHealthStr = health.text;
        baseNumMovesStr = numMoves.text;
        baseDefenceStr = defence.text;

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

        health.text = baseHealthStr + "\n" + unit.currHP + "/" + unit.maxHP + "HP";
        numMoves.text = baseNumMovesStr + "\n" + unit.numMovesRemaining + "/" + unit.maxNumMoves;
        defence.text = baseDefenceStr + "\n" + unit.defense;
    }
}
