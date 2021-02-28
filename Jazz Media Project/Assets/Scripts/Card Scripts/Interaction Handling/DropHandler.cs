using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public BattleManager battleManager;
    public Text cardPlayed;
    string cardPlayedInitialString;

    public void Start()
    {
        cardPlayedInitialString = cardPlayed.text;
        print(cardPlayedInitialString);
    }

    public void OnDrop(PointerEventData eventData)
    {
        bool canPlay = false;

        DragHandler drag = eventData.pointerDrag.GetComponent<DragHandler>();
        CardInterface card = eventData.pointerDrag.GetComponent<CardInterface>();

        if (drag.parentToReturnTo == this.transform)
        {
            print("Guess you decided against that");
            return;
        }

        if (battleManager.gameState == BattleState.Player_Turn)
        {
            canPlay = true;
        }

        if (drag != null && canPlay)
        {

            if (battleManager.player.playCard(eventData.pointerDrag.gameObject) == true)
            {
                cardPlayed.text = cardPlayedInitialString + "\t" +
                    card.getCardTitle().text + "\t\t(" + card.getCardDesc().text + ")";

                Destroy(eventData.pointerDrag.gameObject);

                drag.parentToReturnTo = this.transform;
            }
            else
            {
                cardPlayed.text = "Cannot play " + card.getCardTitle();
            } 
            
        }

        // battleManager.player.currHandSize--;
    }
}
