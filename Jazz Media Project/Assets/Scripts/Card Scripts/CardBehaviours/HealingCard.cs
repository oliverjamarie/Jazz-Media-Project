using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingCard : Card
{
    public int healAmt;

    public override void effect(Unit playedBy, Unit target)
    {
        playedBy.currHP += healAmt;

        if (playedBy.currHP > playedBy.maxHP)
            playedBy.currHP = playedBy.maxHP;
    }


    
}
