using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotItemActive : MonoBehaviour
{

    //이상한곳 누르면 취소
    //옳은곳 누르면 사용
    //인벤토리슬롯 또 누르거나 다른곳누르면 지금누른곳취소되어야함
    public Sprite notActiveSlotSprite;
    public Sprite activeSlotSprite;
    
    public void OnClickSlot()
    {
        if (this.gameObject.GetComponent<InventorySlot>().isSlotActive)
        {
            CancleAllSlotsActive();
        }
        else
        {
            CancleAllSlotsActive();
            if (gameObject.GetComponent<InventorySlot>().getItem() != null)
            {
                this.gameObject.GetComponent<InventorySlot>().getItem().setItemActive(true);
                this.gameObject.GetComponent<InventorySlot>().isSlotActive = true;
                this.gameObject.GetComponent<Image>().sprite = activeSlotSprite;
            }
        }


    }

    public void CancleAllSlotsActive()
    {
        InventorySlot[] inventorySlots = GameObject.FindObjectsOfType<InventorySlot>();
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].getItem() != null) inventorySlots[i].getItem().setItemActive(false);
          
            inventorySlots[i].isSlotActive = false;
            inventorySlots[i].GetComponent<Image>().sprite = notActiveSlotSprite;
        }
    }

}
