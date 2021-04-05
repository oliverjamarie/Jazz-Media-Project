using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public int cost = 1;
    public BattleManager battleManager;
    public string cardTitle;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();
        GetComponent<RectTransform>().localScale = Vector3.one;
    }
    
    abstract public void effect(Unit playedBy, Unit target);
}
