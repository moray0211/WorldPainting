using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;
    void Awake() {

        if(instance != null)
        {
            Debug.LogWarning("인벤토리 인스턴스가 중복하여 발생했습니다.");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 5;
    public List<Item> items = new List<Item>();

    public void Add (Item item)
    {
        if(items.Contains(item)){
            Debug.LogWarning("인벤토리에 같은 아이템 존재");
            return;
        }
        if(items.Count >= space)
        {
            Debug.LogWarning("인벤토리 공간보다 많은 아이템 획득");
            return;
        }
        items.Add(item);
        Debug.Log("아이템 개수 증가 : "+items.Count);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        
    }

    public void Remove (Item item)
    {
        items.Remove(item);
        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void InventorySetActive(bool active)
    {
        Button[] inventorySlotButtons;
        inventorySlotButtons = GameObject.Find("ItemsParent").GetComponentsInChildren<Button>();

        if (!active)
        {
            for (int i=0; i<inventorySlotButtons.Length; i++)
            {
                inventorySlotButtons[i].enabled = false; 
            }
        }else
        {
            for (int i = 0; i < inventorySlotButtons.Length; i++)
            {
                inventorySlotButtons[i].enabled = true;
            }
        }

    }

}
