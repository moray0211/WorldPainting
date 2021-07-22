using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changable : MonoBehaviour
{
    public virtual void change(){ 
        //열고닫을때 쓰임
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (rayhit.collider != null && rayhit.transform == this.gameObject.transform&&!(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()))
            {
                if (GameObject.Find("DialogueManager").GetComponent<DialogueManager>().inConversation == false){
                    change();
                }
            }
        }
    }
}
