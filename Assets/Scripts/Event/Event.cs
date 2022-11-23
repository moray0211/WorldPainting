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

    public GameObject EventAction; // 이벤트 조건이 달성되면 실행할 코드 Prefab
    GameObject EventActionObject; // 생성할 Prefab을 담은 오브젝트
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

    //이벤트를 시작하기 위해 Prefab을 생성하고, 코드를 실행해줄 함수
    public void RunEventAction()
    {
        if (EventAction != null)
        {
            EventActionObject = Instantiate(EventAction.gameObject);
            EventActionObject.transform.SetParent(FindObjectOfType<EventManager>().transform);
            EventActionObject.GetComponent<IEventScript>().StartEvent();
        }
    }

    //이벤트를 종료하면서 Prefab을 삭제하고 이벤트 종료 Flag를 설정할 함수

    public void EndEventAction()
    {
        if (EventActionObject!= null)
        {
            Destroy(EventActionObject);
            //SetCompleteEvent();
        }
    }
}
