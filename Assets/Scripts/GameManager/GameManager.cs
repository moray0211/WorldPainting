using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<string,int> dic;
    public bool[] actives; //오브젝트가 active상태인지 여부 판단(파괴시 false)
    void Start()
    {
        dic=new Dictionary<string,int>();
        actives=new bool[100];
        //initObject(); 
    }

    void Update()
    {
        
    }

    // void initObject(){ //가장 처음 게임 시작했을때 오브젝트 정보 저장
    // Transform[] allChildren = GameObject.Find("Kitchen_background").GetComponentsInChildren<Transform>();
    // int i=0;

    // foreach(Transform child in allChildren) {
    //             Debug.Log(child.name+", num : "+i);
    //             // 자기 자신의 경우엔 무시 
    //             if(child.name != "Kitchen_background"){
    //                 dic.Add(child.name,i);
    //                 i++;
    //             }
    //     }
    // }

    // public void setInactive(string name){ //파괴되는 오브젝트들 기록
    //     int tem=dic[name];
    //     Debug.Log("[setInactive] "+tem+"번 "+name+" 비활성화");
    //     actives[tem]=false;
    // }
    

}
