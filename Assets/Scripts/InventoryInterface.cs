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
    public GameObject hoverPanel;

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
        // Update each sprite and item count once per frame
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

    /* Programmatically add event listeners to objects --  See DisplayInventory.cs and DisplayEquipSlots.cs */
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    /* Event - When cursor enters, starts timer to display item tool tip and sets current slotHovered in MouseData */
    public void OnEnter(GameObject obj)
    {
        MouseData.slotHovered = obj;

        if(itemsDisplayed[obj].item.ID >= 0 && MouseData.tempItemBeingDragged == null) 
        {
            StopAllCoroutines();
            StartCoroutine(StartTimer());
        }
    }

    /* Event - Tracks which inventory interface is active with cursor */
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<InventoryInterface>();
    }
    public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
    }

    /* Event - When cursor exits, the timer for tool tip is stopped and existing tool tip is deactivated */
    public void OnExit(GameObject obj)
    {
        if(MouseData.tempItemBeingDragged == null)
        {
            StopAllCoroutines();
        }

        MouseData.slotHovered = null;
        hoverPanel.SetActive(false);
    }

    /* Event - On start of click drag, creates an image copy of the item */
    public void OnDragStart(GameObject obj)
    {
        StopAllCoroutines();
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
    }
    
    /* Event - Destroys the dragged item image and moves the original item to the slot hovered */
    public void OnDragEnd(GameObject obj)
    {  
        Destroy(MouseData.tempItemBeingDragged);
        if(MouseData.slotHovered)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.itemsDisplayed[MouseData.slotHovered];
            inventory.MoveItem(itemsDisplayed[obj], mouseHoverSlotData);
        }
    }

    /* Event - Keeps the dragged item image on the mouse location */
    public void OnDrag(GameObject obj)
    {
        if(MouseData.tempItemBeingDragged != null)
        {
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    // Handles clicking for equipping armor or using potion on right click
    public void OnPointerDown(GameObject obj, BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;

        // Equip item if right clicked on in inventory
        if(!(pointerEventData.button == PointerEventData.InputButton.Right && itemsDisplayed[obj].item.ID >= 0)) {
            return;
        } else {
            if(itemsDisplayed[obj].ItemObject.type == ItemType.Food) {
                if (healPlayer(itemsDisplayed[obj].ItemObject.data.buffs[0].value) == true)
                {
                    itemsDisplayed[obj].RemoveAmount(1);
                }
            } else {
                InventoryInterface equipment = GameObject.Find("EquipmentScreen").GetComponent<InventoryInterface>();
                // Ensure the right click was not on equipment panel
                if(this.GetComponent<InventoryInterface>() == equipment)
                {
                    return;
                }
                
                if(itemsDisplayed[obj].ItemObject.type == ItemType.Helmet) {
                    inventory.MoveItem(itemsDisplayed[obj], equipment.inventory.container.Items[0]);
                } else if(itemsDisplayed[obj].ItemObject.type == ItemType.Chest) {
                    inventory.MoveItem(itemsDisplayed[obj], equipment.inventory.container.Items[1]);
                } else if(itemsDisplayed[obj].ItemObject.type == ItemType.Legs) {
                    inventory.MoveItem(itemsDisplayed[obj], equipment.inventory.container.Items[2]);
                } else if(itemsDisplayed[obj].ItemObject.type == ItemType.Boots) {
                    inventory.MoveItem(itemsDisplayed[obj], equipment.inventory.container.Items[3]);
                } else if(itemsDisplayed[obj].ItemObject.type == ItemType.Weapon) {
                    inventory.MoveItem(itemsDisplayed[obj], equipment.inventory.container.Items[4]);
                } else if(itemsDisplayed[obj].ItemObject.type == ItemType.Offhand) {
                    inventory.MoveItem(itemsDisplayed[obj], equipment.inventory.container.Items[5]);
                }

                InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.itemsDisplayed[MouseData.slotHovered];
                inventory.MoveItem(itemsDisplayed[obj], mouseHoverSlotData);
            }
        }
    }
    
    /* Timer used for the tool tip popup */
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1);
        ShowToolTip();
    }

    /* Displays a tool tip with item information next to the cursor */
    private void ShowToolTip()
    {
        ItemObject item = inventory.database.GetItem[itemsDisplayed[MouseData.slotHovered].item.ID];
        Item item1 = MouseData.interfaceMouseIsOver.itemsDisplayed[MouseData.slotHovered].item;
        hoverPanel.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = item.name;
        hoverPanel.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = item.description;

        string buffs = "";

        for (int i = 0; i < item1.buffs.Length; i++)
        {
            buffs += "- " + item1.buffs[i].stat + " +" + item1.buffs[i].value;
            if(i < item1.buffs.Length-1)
                buffs += "\n";
        }

        hoverPanel.transform.Find("Buffs").GetComponent<TextMeshProUGUI>().text = buffs;


        hoverPanel.SetActive(true);

        RectTransform hoverTransform = hoverPanel.GetComponent<RectTransform>();

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition.x = Mathf.Clamp(mousePosition.x + hoverTransform.sizeDelta.x / 2, 0 + hoverTransform.rect.width / 2, Screen.width - hoverTransform.rect.width / 2);
        mousePosition.y = Mathf.Clamp(mousePosition.y - hoverTransform.sizeDelta.y / 2, 0 + hoverTransform.rect.height / 2, Screen.height - hoverTransform.rect.height / 2);
        hoverTransform.transform.position = mousePosition;
    }

    public bool healPlayer(int healAmount)
    {
        GameObject playerObj = GameObject.Find("PlayerPersistency");
        PlayerPersistency playerStats = playerObj.GetComponent<PlayerPersistency>();
        if(playerStats.currentHP < playerStats.maxHP)
        {
            playerStats.Heal(healAmount);
            return true;
        }
        else
        {
            return false;
        }
        
    }


}

public static class MouseData
{
    public static InventoryInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHovered;
}