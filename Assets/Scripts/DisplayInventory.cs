using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{

    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    private GameObject grid;

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        grid = GameObject.Find("InventoryGrid");
        for (int i = 0; i < inventory.container.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, grid.transform);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = inventory.container[i].item.uiDisplay;

            itemsDisplayed.Add(inventory.container[i], obj);
        }

        // Make remaining empty slots
        for (int i = inventory.container.Length; i < 24; i++)
        {
            Instantiate(inventoryPrefab, grid.transform);
        }
    }

    public void UpdateDisplay()
    {
        //foreach (KeyValuePair<InventorySlot, GameObject> _slot in itemsDisplayed)
        //{
        //    _slot.Value.transform.GetChild(0).GetComponent<Image>().sprite = inventory.database.GetItem[_slot.Key.item.id].uiDisplay;
        //}
    }
}
