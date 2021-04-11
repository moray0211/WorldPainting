using UnityEngine;

[CreateAssetMenu(fileName = "New Switch", menuName = "Custom/Switch")]
public class Switch : ScriptableObject
{
    public bool isSwitchActive = false;
    [TextArea(3, 10)]
    public string comment = "스위치 설명 주석";

    public void setSwitchActive(bool active)
    {
        isSwitchActive = active;
    }

    public bool getSwitchActive()
    {
        return isSwitchActive;
    }
}
