using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttack : Card
{
    public int damage;

    public override void effect(Unit playedBy, Unit target)
    {
        playedBy.attack(target, damage);
    }

}
