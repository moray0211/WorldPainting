using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Event))]
[ExecuteInEditMode]
public class EventDebugTool : EditorWindow
{
    int selectevent = 0;
    [MenuItem("Debug/EventDebug")]
    public static void Open()
    {
        GetWindow<EventDebugTool>().maxSize = new Vector2(400,400);
        //ó�� ������ �����Ҷ�
        GetWindow<EventDebugTool>().titleContent = new GUIContent("�̺�Ʈ �����");
    }

    private void OnEnable()
    {
    }
    private void OnGUI()
    {
        //GUI �� ������ �� �����ϰ� �Ǵ� �Լ�
        GUILayout.BeginArea(new Rect(50, 20, 1000, 1000));
        GUILayout.BeginVertical();
        EditorGUI.HelpBox(new Rect(0, 10, 300, 50), "�̺�Ʈ�� �����ϰ� ���� ��ư�� ���� �׽�Ʈ�غ���!", MessageType.Info);
        List<Event> EventList = new List<Event>();
        foreach (Event e in Resources.LoadAll("Event"))
        {
            EventList.Add(e); //���� �Ҹ���� ���� �̺�Ʈ�鸸 �߰�
        }
        
        string[] eventnames = new string[EventList.Count];
        for(int i=0;i<EventList.Count;i++)
        {
            eventnames[i] = EventList[i].name;
        }

        GUILayout.Space(100);
        selectevent = EditorGUI.Popup(new Rect(0,70,200,20), selectevent, eventnames);

        GUILayout.BeginVertical();
        EditorGUILayout.LabelField("EventName : " + EventList[selectevent].EventName);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("EventDescription : " + EventList[selectevent].EventDescription);
        GUILayout.EndVertical();
        
        GUILayout.Space(10);
        GUI.backgroundColor = new Color(174.0f, 169.0f, 232.0f, 1.0f);
        if (GUILayout.Button("�̺�Ʈ ����",GUILayout.MinWidth(200), GUILayout.MaxWidth(200)))
        {
            EventList[selectevent].RunEventAction();
        };
        GUI.backgroundColor = Color.white;
        GUILayout.EndVertical();
        GUILayout.EndArea();
        
    }
}
