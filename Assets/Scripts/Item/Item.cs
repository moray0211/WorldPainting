using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item"; //이름
    public string itemDef; //설명
    public Sprite icon = null;
    bool isItemActive = false;

    public void setItemActive(bool active) {
        isItemActive = active;
    }

    public bool getItemActive()
    {
        return isItemActive;
    }

}
