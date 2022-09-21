using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEventScript : MonoBehaviour
{
    public string EventName; //�̸�

    private void Start()
    {
        
    }

    public virtual void StartEvent()
    {
        // �̺�Ʈ�� ����Ǹ� �����ϴ� �ڵ�
    }

    public virtual void EndEvent()
    {
        //�̺�Ʈ�� ���� �� ��ó���ϴ� �ڵ�
        GameObject.FindObjectOfType<EventManager>().RunAfterEvent();
    }
}
