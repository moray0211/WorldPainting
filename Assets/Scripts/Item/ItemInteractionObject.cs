using UnityEngine;

public class ItemInteractionObject : ItemInteractable
{

    public Item interactableItem; //상호작용할 아이템들
    public bool destroyObject = false; //사용시 오브젝트 사라짐 유무
    public bool destroyItem = false; //사용시 아이템 사라짐 유무

    public bool isTriggerDiaglogue=false; //대화를 진행할 것인지
    public Dialogue dialogue; //대화 진행한다면 그 내용
    public Switch[] reqSwitch; //아이템을 사용하기 위한 스위치
    public Switch[] onSwitchAfterInteract; //Interact 이후 On되는 스위치

    [TextArea(3, 10)]
    public string comment = "상호작용 설명 주석";

    public override void Interact()
    {
        base.Interact();
        bool allReqSwitchOn = true;

        if(reqSwitch!=null) {
             for (int i = 0; i < reqSwitch.Length; i++)
            {
                if (!reqSwitch[i].getSwitchActive())
                {
                    allReqSwitchOn = false;
                }
            }
            if (allReqSwitchOn) InteractItem();
        }else InteractItem();
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
                if (onSwitchAfterInteract.Length!=0){
                    for(int j=0;j<onSwitchAfterInteract.Length;j++){
                        onSwitchAfterInteract[j].setSwitchActive(true);
                        //상호작용 후 켜줄 스위치가 있다면 On해주기
                    }
                } 
                Object.FindObjectOfType<InventorySlotItemActive>().CancleAllSlotsActive();

                if(isTriggerDiaglogue){ //아이템 사용시 대화한다면
                    FindObjectOfType<DialogueManager>().dialogueCanvas.SetActive(true); //대화창 호출
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue, new DialogueTrigger.SwitchOnOffInf());
                }
        
                return;
            
            

            }
        }
        Object.FindObjectOfType<InventorySlotItemActive>().CancleAllSlotsActive();
    }

    private void Awake()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (!gameManager.IsReset)
        {
            destoryIfNeeded();
        }
    }
    public void destoryIfNeeded()
    {
        if (onSwitchAfterInteract != null)
        {
            for(int i=0;i< onSwitchAfterInteract.Length; i++)
            {
                if (!onSwitchAfterInteract[i].getSwitchActive()) return;
            }
            Destroy(gameObject);
        }
    }


}
