using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayEquipSlots : InventoryInterface
{
    public GameObject[] slots;
    public override void CreateDisplay()
    {
        itemsDisplayed = new();

        // Apply event listeners for each item slot displayed
        for(int i = 0; i < inventory.container.Items.Length; i++)
        {
            var obj = slots[i];
            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            itemsDisplayed.Add(obj, inventory.container.Items[i]);
        }
    }
}
