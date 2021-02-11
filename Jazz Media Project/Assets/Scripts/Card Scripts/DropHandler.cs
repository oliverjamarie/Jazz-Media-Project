using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        print(eventData.pointerDrag.name + " has been dropped onto " + gameObject.name);

        DragHandler drag = eventData.pointerDrag.GetComponent<DragHandler>();

        if (drag != null)
        {
            drag.parentToReturnTo = this.transform;
        }
    }
}
