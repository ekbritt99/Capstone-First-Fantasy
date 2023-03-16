using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DisplayInventory : InventoryInterface
{
    public GameObject inventoryPrefab;
    private GameObject grid;
    public Button backButton;

    public override void CreateDisplay()
    {
        grid = GameObject.Find("InventoryGrid");
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

        // Add button event listener if the button exists
        if(backButton != null)
            backButton.onClick.AddListener(delegate { GameManager1.Instance.GoToPreviousScene(); });

        // Apply event listeners for each item slot displayed.
        for (int i = 0; i < inventory.container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, grid.transform);
            var text = obj.transform.GetChild(1);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            AddEvent(obj, EventTriggerType.PointerDown, e => OnPointerDown(obj, e));
        
        
            itemsDisplayed.Add(obj, inventory.container.Items[i]);
        }
    }
}

