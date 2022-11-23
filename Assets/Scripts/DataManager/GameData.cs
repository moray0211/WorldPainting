using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public Item[] inventory_items;
    public List<Item> save_items;
    public List<Item> save_switches;
    public bool[] IsActive; //캐릭터들이 활성화되었는지 기록하는 변수
    bool[] EyeButtonLock = { false, false, false }; //시점 변환이 활성화되었는지 기록하는 변수
}
