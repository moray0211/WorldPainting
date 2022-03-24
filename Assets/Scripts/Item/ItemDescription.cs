using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDescription : MonoBehaviour
{
    public GameObject itemDesc;
    public Text itemNameText;
    public Text itemDefText;
    InventorySlot inventorySlot;

    void Start()
    {
        if (itemDesc != null) itemDesc.SetActive(false);

        inventorySlot = this.gameObject.GetComponent<InventorySlot>();
    }

    public void VisibleDesc()
    {
        if (inventorySlot.getItem() != null)
        {
            if (itemDesc != null)
            {
                itemDesc.SetActive(true);
                itemNameText.text = inventorySlot.getItem().itemname;
                itemDefText.text = inventorySlot.getItem().itemDescription;
            }
        }

    }

    public void InvisibleDesc()
    {
        if (itemDesc != null) itemDesc.SetActive(false);
    }
}
