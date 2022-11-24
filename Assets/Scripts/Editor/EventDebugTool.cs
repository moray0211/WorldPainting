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
        //처음 에디터 세팅할때
        GetWindow<EventDebugTool>().titleContent = new GUIContent("이벤트 디버그");
    }

    private void OnEnable()
    {
    }
    private void OnGUI()
    {
        //GUI 가 열렸을 때 실행하게 되는 함수
        GUILayout.BeginArea(new Rect(50, 20, 1000, 1000));
        GUILayout.BeginVertical();
        EditorGUI.HelpBox(new Rect(0, 10, 300, 50), "이벤트를 선택하고 실행 버튼을 눌러 테스트해보자!", MessageType.Info);
        List<Event> EventList = new List<Event>();
        foreach (Event e in Resources.LoadAll("Event"))
        {
            EventList.Add(e); //아직 소모되지 않은 이벤트들만 추가
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
        if (GUILayout.Button("이벤트 실행",GUILayout.MinWidth(200), GUILayout.MaxWidth(200)))
        {
            EventList[selectevent].RunEventAction();
        };
        GUI.backgroundColor = Color.white;
        GUILayout.EndVertical();
        GUILayout.EndArea();
        
    }
}
