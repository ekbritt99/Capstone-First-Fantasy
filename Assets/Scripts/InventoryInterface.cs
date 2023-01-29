using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class InventoryInterface : MonoBehaviour
{
    public InventoryObject inventory;
    public Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

    public Player player;
    
    public void OnEnable()
    {
        for(int i = 0; i < inventory.container.Items.Length; i++)
        {
            inventory.container.Items[i].parent = this;
        }
        CreateDisplay();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    public abstract void CreateDisplay();

    public void Update()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if(_slot.Value.item.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.ID].uiDisplay;
                _slot.Key.transform.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }

        }
    }

    
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        MouseData.slotHovered = obj;
        // player.mouseItem.hoverObj = obj;
        // if(itemsDisplayed.ContainsKey(obj))
        // {
        //     player.mouseItem.hoverItem = itemsDisplayed[obj];
        // }
    }
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<InventoryInterface>();
    }
    public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
    }
    public void OnExit(GameObject obj)
    {
        MouseData.slotHovered = null;
        // player.mouseItem.hoverObj = null;
        // player.mouseItem.hoverItem = null;
    }
    public void OnDragStart(GameObject obj)
    {
        GameObject tempItem = null;
        if(itemsDisplayed[obj].item.ID >= 0) 
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(50, 50);
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
            img.sprite = itemsDisplayed[obj].ItemObject.uiDisplay;
            img.raycastTarget = false;
        }

        MouseData.tempItemBeingDragged = tempItem;

        // var mouseObject = new GameObject();
        // var rt = mouseObject.AddComponent<RectTransform>();
        // rt.sizeDelta = new Vector2(50, 50);
        // mouseObject.transform.SetParent(transform.parent);

        // if(itemsDisplayed[obj].ID >= 0)
        // {
        //     var image = mouseObject.AddComponent<Image>();
        //     image.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
        //     image.raycastTarget = false;
        // }
        // player.mouseItem.obj = mouseObject;
        // player.mouseItem.item = itemsDisplayed[obj];
    }
    
    public void OnDragEnd(GameObject obj)
    {  
        Destroy(MouseData.tempItemBeingDragged);
        if(MouseData.slotHovered)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.itemsDisplayed[MouseData.slotHovered];
            inventory.MoveItem(itemsDisplayed[obj], mouseHoverSlotData);
        }
        // if(player.mouseItem.hoverObj)
        // {
        //     inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[player.mouseItem.hoverObj]);
        // }
        // else
        // {
        //     // inventory.RemoveItem(itemsDisplayed[obj].item);
        // }
        // Destroy(player.mouseItem.obj);
        // player.mouseItem.item = null;
    }
    public void OnDrag(GameObject obj)
    {
        if(MouseData.tempItemBeingDragged != null)
        {
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
        // if(player.mouseItem.obj != null)
        //     player.mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
    }




}

public static class MouseData
{
    public static InventoryInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHovered;
}