﻿using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item"; //이름
    public string itemDef; //설명
    public Sprite icon = null;
    bool isItemActive = false;
    public bool isItemDestroyInScene=false;
    public Dialogue[] description;

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
