using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UnitUI : MonoBehaviour
{
    BattleManager battleManager;
    Unit unit;

    //public GameObject numMovesRemainingGO, attackPtsGO, defStatsGO;
    public TextMeshProUGUI numMovesRemaining, attackPts, defStats;
    public Slider healthBar;
    

    public void Start()
    {
        //numMovesRemaining = numMovesRemainingGO.GetComponent<TMP_Text>();
        //attackPts = attackPtsGO.GetComponent<TMP_Text>();
        //defStats = defStatsGO.GetComponent<TMP_Text>();

        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();

        if (battleManager == null)
        {
            return;
        }

        getUnit();

        if (unit == null)
        {
            return;
        }

        healthBar.maxValue = unit.maxHP;

        setText();
    }

    public void Update()
    {
        if (unit == null)
        {
            getUnit();
            healthBar.maxValue = unit.maxHP;
        }

        healthBar.value = unit.currHP;

        setText();
    }

   void getUnit()
    {
        if (tag == "PlayerUI")
            unit = battleManager.playerUnit;
        else if (tag == "EnemyUI")
            unit = battleManager.enemyUnit;
        else
            print("WTF");
    }

    void setText()
    {
        numMovesRemaining.SetText(unit.numMovesRemaining.ToString());
        attackPts.SetText(unit.attackPts.ToString());
        defStats.SetText(unit.defense.ToString() + " | " + unit.defensePts.ToString()) ;
    }
}
