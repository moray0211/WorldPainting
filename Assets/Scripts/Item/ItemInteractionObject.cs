using UnityEngine;

public class ItemInteractionObject : ItemInteractable
{

    public Item interactableItem; //상호작용할 아이템
    public bool destroyObject = false; //사용시 오브젝트 사라짐 유무
    public bool destroyItem = false; //사용시 아이템 사라짐 유무

    [TextArea(3, 10)]
    public string comment = "상호작용 설명 주석";

    public override void Interact()
    {
        base.Interact();

        InteractItem();
    }

    void InteractItem()
    {

        InventorySlot[] inventorySlots = GameObject.FindObjectsOfType<InventorySlot>();
  
        for (int i = 0; i < inventorySlots.Length; i++)
        {

            if (inventorySlots[i].getItem() != null && inventorySlots[i].getItem() == interactableItem && inventorySlots[i].getItem().getItemActive())
            {
                //상호작용
                inventorySlots[i].isSlotActive = false;
                inventorySlots[i].GetComponent<InventorySlotItemActive>().CancleAllSlotsActive();
                if (destroyItem) Inventory.instance.Remove(interactableItem);
                if (destroyObject) Destroy(gameObject);
                Object.FindObjectOfType<InventorySlotItemActive>().CancleAllSlotsActive();
                return;
            }

        }
        Object.FindObjectOfType<InventorySlotItemActive>().CancleAllSlotsActive();
    }

}
