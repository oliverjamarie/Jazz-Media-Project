using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public BattleManager battleManager;

    public void OnDrop(PointerEventData eventData)
    {
        bool canPlay = false;

        DragHandler drag = eventData.pointerDrag.GetComponent<DragHandler>();
        //CardInterface card = eventData.pointerDrag.GetComponent<CardInterface>();
        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (drag.parentToReturnTo == this.transform)
        {
            print("Guess you decided against that");
            return;
        }

        if (battleManager == null)
        {
            battleManager = GameObject.FindGameObjectWithTag("Battle Manager").GetComponent<BattleManager>();
        }

        if (battleManager.gameState == BattleState.Player_Turn ||
                battleManager.gameState == BattleState.Player_Champ_Turn)
        {
            canPlay = true;
        }

        if (drag != null && canPlay)
        {
            if (battleManager.getPlayer().playCard(eventData.pointerDrag.gameObject) == true)
            {
                Transform trans = GameObject.FindGameObjectWithTag("DiscardPile").transform;

                drag.parentToReturnTo = trans;
            }
            
        }

        // battleManager.player.currHandSize--;
    }
}
