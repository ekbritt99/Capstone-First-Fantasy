using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyCounter : MonoBehaviour
{

    private TextMeshProUGUI counterText;
    public InventoryObject playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        counterText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = playerInventory.container.gold.getCurrency().ToString();
    }
}
