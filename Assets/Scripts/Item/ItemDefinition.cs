using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDefinition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject itemDef;
    public Text itemNameText;
    public Text itemDefText;
    Transform pos;
    InventorySlot inventorySlot;
    void Start()
    {
        if (itemDef != null) itemDef.SetActive(false);
        pos = this.gameObject.transform;

        inventorySlot = this.gameObject.GetComponent<InventorySlot>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inventorySlot.getItem() != null)
        {
            if (itemDef != null)
            {
                itemDef.SetActive(true);
                itemDef.transform.position = new Vector3(pos.position.x + 70, pos.position.y - 100, pos.position.z);
            }
            itemNameText.text = inventorySlot.getItem().name;
            itemDefText.text = inventorySlot.getItem().itemDef;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (itemDef != null) itemDef.SetActive(false);
    }

}
