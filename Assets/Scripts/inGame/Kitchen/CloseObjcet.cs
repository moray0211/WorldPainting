using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseObjcet : MonoBehaviour
{ //닫을 오브젝트
    public GameObject changeobj; //변경할 오브젝트(보통 맵 전체)
    //public GameObject openobj; //openobj가 들어있는 오브젝트

    public void setopen(){
        changeobj.SetActive(false);
        FindObjectOfType<EyeButtonAnimator>().ColorRetry();
    }

    public void setclose(){
        changeobj.SetActive(true);
        setacvivechild(); //자식들까지 active 시켜준다 (색상 적용을 위해)
        FindObjectOfType<EyeButtonAnimator>().ColorRetry();
        this.gameObject.SetActive(false);
    }

    void setacvivechild(){ //자식 오브젝트까지 모두 active 상태로 만드는 함수
        for(int i=0;i<changeobj.transform.childCount;i++){
            changeobj.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
