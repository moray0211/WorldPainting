using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Switch", menuName = "Custom/Switch")]
public class Switch : ScriptableObject
{
    public bool isSwitchActiveAtFirst = false;
    public bool isSwitchActive;
    [TextArea(3, 10)]
    public string comment = "스위치 설명 주석";

    public void setSwitchActive(bool active)
    {
        isSwitchActive = active;

        Switch s = Resources.Load("Switches/"+name) as Switch;
        if (s == null) return;

        EditorUtility.SetDirty(s);
    }

    public bool getSwitchActive()
    {
        return isSwitchActive;
    }

    private void Awake()
    {
        isSwitchActive = isSwitchActiveAtFirst;
    }

}
