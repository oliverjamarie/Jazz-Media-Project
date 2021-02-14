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


        if (battleManager.gameState == BattleState.Player_Turn)
        {
            canPlay = true;
        }

        if (drag != null && canPlay)
        {
            drag.parentToReturnTo = this.transform;

            card.effect();

            cardPlayed.text = cardPlayedInitialString + "\t"+
                card.getCardTitle().text + "\t\t(" + card.getCardDesc().text+")";

            Destroy(eventData.pointerDrag.gameObject);
        }

        battleManager.player.currHandSize--;
    }
}
