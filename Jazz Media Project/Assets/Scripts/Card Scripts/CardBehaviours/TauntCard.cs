using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TauntCard : Card
{

    public override void effect(Unit playedBy, Unit target)
    {
        playedBy.maxNumMoves++;
    }

}
