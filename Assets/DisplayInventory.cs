using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{

    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    public GameObject grid;

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
        for (int i = 0; i < inventory.container.Count; i++)
        {
            var obj = Instantiate(inventoryPrefab);
            obj.transform.SetParent(grid.transform);
        }
    }

    public void UpdateDisplay()
    {
        //obj.transform.GetChild(0).GetComponent<Image>().sprite = inventory.container[i].item.uiDisplay;
    }
}
