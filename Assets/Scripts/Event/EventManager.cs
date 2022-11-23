using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventManager : MonoBehaviour
{
    Queue<Event> EventQueue = new Queue<Event>();

    Event CurrenEvent;
    bool IsInEvent = false; //�̺�Ʈ �������̸� true

    private void Start()
    {
        foreach (Event e in Resources.LoadAll("Event"))
        {
            if (!e.getIsComplete()) EventQueue.Enqueue(e); //���� �Ҹ���� ���� �̺�Ʈ�鸸 �߰�
        }
        CurrenEvent = EventQueue.Peek();
    }

    private void Update()
    {
        if(EventQueue.Count>0 && EventQueue.Peek() != null && !IsInEvent 
            && CurrenEvent.IsRunable() && !FindObjectOfType<DialogueManager>().inConversation)
        { //����ؼ� ���� ���� �̺�Ʈ Listen
            Debug.Log("�̺�Ʈ ���� , " + CurrenEvent.name);
            IsInEvent = true;
            CurrenEvent.RunEventAction();
        }
    }


    //���� �̺�Ʈ�� �Ѿ�� �ڵ�
    void ProcessEvent()
    {
        if(EventQueue.Count > 0)
        {
            EventQueue.Peek().EndEventAction();
            //EditorUtility.SetDirty(EventQueue.Peek());
            EventQueue.Peek();
            EventQueue.Dequeue();
            if(EventQueue.Count > 0)    CurrenEvent = EventQueue.Peek(); //���� �̺�Ʈ ��
            IsInEvent = false;
        }
    }

    //��ȭ�� �ܺ� ���� ������ ���� �� ���� �̺�Ʈ�� �Ѿ�� �Լ�
    public void RunAfterEvent()
    {
        //�̺�Ʈ �������̸� ���� �̺�Ʈ�� �Ѿ
        if(IsInEvent) ProcessEvent();
    }
}
