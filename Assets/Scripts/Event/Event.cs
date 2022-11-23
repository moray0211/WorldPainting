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

    public GameObject EventAction; // �̺�Ʈ ������ �޼��Ǹ� ������ �ڵ� Prefab
    GameObject EventActionObject; // ������ Prefab�� ���� ������Ʈ
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

    //�̺�Ʈ�� �����ϱ� ���� Prefab�� �����ϰ�, �ڵ带 �������� �Լ�
    public void RunEventAction()
    {
        if (EventAction != null)
        {
            EventActionObject = Instantiate(EventAction.gameObject);
            EventActionObject.transform.SetParent(FindObjectOfType<EventManager>().transform);
            EventActionObject.GetComponent<IEventScript>().StartEvent();
        }
    }

    //�̺�Ʈ�� �����ϸ鼭 Prefab�� �����ϰ� �̺�Ʈ ���� Flag�� ������ �Լ�

    public void EndEventAction()
    {
        if (EventActionObject!= null)
        {
            Destroy(EventActionObject);
            //SetCompleteEvent();
        }
    }
}
