using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{

    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDisplay()
    {
        GameObject grid = GameObject.Find("Grid");
        for (int i = 0; i < inventory.container.Count; i++)
        {
            var obj = Instantiate(inventoryPrefab);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = inventory.container[i].item.uiDisplay;
            obj.transform.parent = grid.transform;
        }
    }
}
