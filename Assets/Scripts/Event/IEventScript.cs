using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEventScript : MonoBehaviour
{
    public string EventName; //이름

    private void Start()
    {
        
    }

    public virtual void StartEvent()
    {
        // 이벤트가 실행되면 실행하는 코드
    }

    public virtual void EndEvent()
    {
        //이벤트가 끝날 때 후처리하는 코드
        GameObject.FindObjectOfType<EventManager>().RunAfterEvent();
    }
}
