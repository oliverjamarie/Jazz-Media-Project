using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitsuneChampCard : Card
{
    public GameObject kitsuneChampPrefab;

    public override void effect(Unit playedBy, Unit target)
    {
        battleManager.setupChamp(kitsuneChampPrefab);
    }
}
