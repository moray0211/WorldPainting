using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
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
