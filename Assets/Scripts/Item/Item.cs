using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item")]
public class Item : ScriptableObject
{

    public string itemname; //이름
    [TextArea(3,10)]
    public string itemDescription; //설명
    public Sprite icon = null;
    bool isItemActive = false;
    public bool isItemDestroyInScene=false;

    public void setItemActive(bool active) {
        isItemActive = active;
    }

    public bool getItemActive()
    {
        return isItemActive;
    }

    public void setItemDestory(bool exist)
    {
        isItemDestroyInScene = exist;

        Item item = Resources.Load("Items/"+name) as Item;
        if (item == null) return;

        EditorUtility.SetDirty(item);
    }

    public bool getItemDestory()
    {
        return isItemDestroyInScene;
    }

}
