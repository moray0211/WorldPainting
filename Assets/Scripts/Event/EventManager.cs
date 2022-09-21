using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventManager : MonoBehaviour
{
    Queue<Event> EventQueue = new Queue<Event>();
    public GameObject[] CharacterObjects;

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
        if(EventQueue.Count>0 && EventQueue.Peek() != null && !IsInEvent && CurrenEvent.IsRunable() && !FindObjectOfType<DialogueManager>().inConversation)
        { //����ؼ� ���� ���� �̺�Ʈ Listen
            Debug.Log("�̺�Ʈ ���� , " + CurrenEvent.name);
            IsInEvent = true;
            CurrenEvent.RunEventAction();
        }
    }


    void ProcessEvent()
    {
        if(EventQueue.Count > 0)
        {
            EventQueue.Peek().EndEventAction();
            EditorUtility.SetDirty(EventQueue.Peek());
            EventQueue.Peek();
            EventQueue.Dequeue();
            if(EventQueue.Count > 0)    CurrenEvent = EventQueue.Peek(); //���� �̺�Ʈ ��
            IsInEvent = false;
        }
    }


    public void RunAfterEvent()
    {
        //�̺�Ʈ �������̸� ���� �̺�Ʈ�� �Ѿ�� �Լ�
        if(IsInEvent) ProcessEvent();
    }
}
