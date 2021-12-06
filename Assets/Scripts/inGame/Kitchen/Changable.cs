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
            RaycastHit2D[] rayhits = Physics2D.RaycastAll(mousePos, Vector2.zero, 20);
            if (rayhits.Length > 0)
            {
                int priorityindex = 0;
                for (int i = 1; i < rayhits.Length; i++) //여러 오브젝트가 겹쳐있는 경우, 레이어가 더 높은 오브젝트를 선택
                {
                    if (rayhits[i].collider.gameObject.GetComponent<SpriteRenderer>() == true && rayhits[i].collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Layer3")
                        priorityindex = i;
                }

                RaycastHit2D rayhit = rayhits[priorityindex];
                if (rayhit.collider != null && rayhit.transform == this.gameObject.transform && !(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()))
                {
                    if (GameObject.Find("DialogueManager").GetComponent<DialogueManager>().inConversation == false)
                    {
                        change();
                    }
                }
            }
        }
    }
}
