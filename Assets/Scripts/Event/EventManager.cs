using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventManager : MonoBehaviour
{
    Queue<Event> EventQueue = new Queue<Event>();

    Event CurrenEvent;
    bool IsInEvent = false; //이벤트 진행중이면 true

    private void Start()
    {
        foreach (Event e in Resources.LoadAll("Event"))
        {
            if (!e.getIsComplete()) EventQueue.Enqueue(e); //아직 소모되지 않은 이벤트들만 추가
        }
        CurrenEvent = EventQueue.Peek();
    }

    private void Update()
    {
        if(EventQueue.Count>0 && EventQueue.Peek() != null && !IsInEvent 
            && CurrenEvent.IsRunable() && !FindObjectOfType<DialogueManager>().inConversation)
        { //계속해서 제일 앞의 이벤트 Listen
            Debug.Log("이벤트 시작 , " + CurrenEvent.name);
            IsInEvent = true;
            CurrenEvent.RunEventAction();
        }
    }


    //다음 이벤트로 넘어가는 코드
    void ProcessEvent()
    {
        if(EventQueue.Count > 0)
        {
            EventQueue.Peek().EndEventAction();
            //EditorUtility.SetDirty(EventQueue.Peek());
            EventQueue.Peek();
            EventQueue.Dequeue();
            if(EventQueue.Count > 0)    CurrenEvent = EventQueue.Peek(); //다음 이벤트 픽
            IsInEvent = false;
        }
    }

    //대화나 외부 설정 조작이 끝난 후 다음 이벤트로 넘어가는 함수
    public void RunAfterEvent()
    {
        //이벤트 실행중이면 다음 이벤트로 넘어감
        if(IsInEvent) ProcessEvent();
    }
}
