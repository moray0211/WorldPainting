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
    public bool[] IsActive; //ĳ���͵��� Ȱ��ȭ�Ǿ����� ����ϴ� ����
    bool[] EyeButtonLock = { false, false, false }; //���� ��ȯ�� Ȱ��ȭ�Ǿ����� ����ϴ� ����
}
