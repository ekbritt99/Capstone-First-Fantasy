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
            AddEvent(obj, EventTriggerType.PointerDown, e => OnPointerDown(obj, e));

            itemsDisplayed.Add(obj, inventory.container.Items[i]);
        }
    }

    public void OnPointerDown(GameObject obj, BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;

        // Equip item if right clicked on in inventory
        if(!(pointerEventData.button == PointerEventData.InputButton.Right && itemsDisplayed[obj].item.ID > 0)) {
            return;
        } else {
            InventoryInterface playerInventory = GameObject.Find("InventoryScreen").GetComponent<InventoryInterface>();
            Debug.Log("Player inventory: " + playerInventory);
            if(playerInventory == null)
                return;
            int emptySlot = playerInventory.inventory.FindEmptySlot();
            if(emptySlot > -1)
            {
                inventory.MoveItem(itemsDisplayed[obj], playerInventory.inventory.container.Items[emptySlot]);
            }
            Debug.Log("Empty slot: " + emptySlot);
            return;
        }
    }
}
