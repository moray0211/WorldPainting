using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEventScript : MonoBehaviour
{
    public string EventName; //�̺�Ʈ �̸�

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
    }

    public void PasteValue<T>(T orgin, T datavalue)
    {
        orgin = datavalue;
    }
}
