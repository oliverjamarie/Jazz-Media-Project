using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour 
{
    public List<GameObject> cards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gameObject in cards)
        {
            if (gameObject.GetComponent<CardInterface>() == null)
            {
                throw new System.NotImplementedException();
            }
        }
    }

    public GameObject dealCard()
    {
        int rand = (int)(Random.value * 100) % cards.Count;

        return cards[rand];
    }

    public GameObject[] dealCards(int numCards)
    {
        List<GameObject> dealtCards = new List<GameObject>();

        for (int i = 0; i < numCards; i++)
        {
            dealtCards.Add(dealCard());
        }

        return dealtCards.ToArray();
    }
}
