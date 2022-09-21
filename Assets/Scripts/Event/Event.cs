using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Custom/Event")]
public class Event : ScriptableObject
{
    public string EventName; //�̸�
    [TextArea(3, 10)]
    public string EventDescription; //����

    public bool IsComplete = false;

    public Switch[] ReqSwitch; //�̺�Ʈ�� �����ϱ� ���� �ʿ��� ����

    public GameObject EventAction; // �̺�Ʈ ������ �޼��Ǹ� ������ �ڵ� ������
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
    { //�̺�Ʈ �Ҹ�Ǹ� True
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
