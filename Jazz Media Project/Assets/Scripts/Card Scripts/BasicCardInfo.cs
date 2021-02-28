using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicCardInfo : MonoBehaviour
{
    public int cardCost = 1;
    public Text cardCostText, cardTitle, cardDesc;

    void Start()
    {
        cardCostText.text = cardCost.ToString(); 
    }

    public void updateCost(int cost)
    {
        cardCost = cost;
        cardCostText.text = cardCost.ToString();
    }
}
