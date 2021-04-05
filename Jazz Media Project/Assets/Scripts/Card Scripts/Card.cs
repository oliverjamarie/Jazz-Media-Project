using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public int cost = 1;
    public Text costText;
    public BattleManager battleManager;
    public string cardTitle;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();
        costText.text = cost.ToString();
    }
    
    abstract public void effect(Unit playedBy, Unit target);
}
