using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenObj :  Changable { //열기위한 스크립트
    public Switch[] reqSwitch; //변경하기위해 필요한 스위치
    public GameObject changeobj; //변경할 오브젝트
    void Start()
    {
        changeobj.SetActive(false);
    }

    public override void change()
    {
        base.change();
        changeOpentrigger();
    }

    public void changeOpentrigger(){
        openobj();
    }

    void openobj(){//오브젝트의 행동
        if(reqSwitch.Length!=0)//스위치 판정
        {
            for (int i = 0; i < reqSwitch.Length; i++)
            {
                if (!reqSwitch[i].getSwitchActive())
                {
                    return;
                }
            }
        }
        changeobj.SetActive(true);
        setacvivechild();
        changeobj.GetComponent<CloseObjcet>().setopen();
    }

    void setacvivechild(){ //자식 오브젝트까지 모두 active 상태로 만드는 함수
        for(int i=0;i<changeobj.transform.childCount;i++){
            changeobj.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
