using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaObakeChampCard : Card
{
    public GameObject kasaObakeChampPrefab;

    public override void effect(Unit playedBy, Unit target)
    {
        battleManager.setupChamp(kasaObakeChampPrefab);
    }
}
