using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicDefend : Card
{
    public int defenseValue;

    public override void effect(Unit playedBy, Unit target)
    {
        playedBy.defense += defenseValue + playedBy.defensePts;
        print(playedBy.defense + "\t" + defenseValue + "\t" + playedBy.defensePts);
    }

}
