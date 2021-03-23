using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreparedAttackCard : Card
{

    public int modifier = 1; 

    public override void effect(Unit playedBy, Unit target)
    {
        playedBy.attackPts += modifier;
    }

    
}
