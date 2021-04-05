using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedDefenseCard : Card
{
    public int modifier = 1;

    public override void effect(Unit playedBy, Unit target)
    {
        print("Prepared Defense Card played by: " + playedBy.name);
        playedBy.defensePts += modifier;
    }
}
