using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Custom/Event")]
public class Event : ScriptableObject
{
    public string EventName; //이름
    [TextArea(3, 10)]
    public string EventDescription; //설명

    public bool IsComplete = false;

    public Switch[] ReqSwitch; //이벤트를 실행하기 위해 필요한 조건

    public GameObject EventAction; // 이벤트 조건이 달성되면 실행할 코드 프리팹
    GameObject EventActionObject;
    public bool IsRunable()
    {
        foreach (Switch s in ReqSwitch)
        {
            if (!s.isSwitchActive) { return false; }
        }
        return true;
    }

    public void SetCompleteEvent()
    { //이벤트 소모되면 True
        IsComplete = true;
    }
    public bool getIsComplete()
    {
        return IsComplete;
    }

    public void RunEventAction()
    {
        if (EventAction != null)
        {
            EventActionObject = Instantiate(EventAction.gameObject);
            EventActionObject.GetComponent<IEventScript>().StartEvent();
        }
    }

    public void EndEventAction()
    {
        if (EventActionObject!= null)
        {
            Destroy(EventActionObject);
            SetCompleteEvent();
        }
    }
}
