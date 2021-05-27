using UnityEngine;

public class ItemInteractable : MonoBehaviour
{

    public virtual void Interact()
    {
        //아이템과 상호작용
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
                    Debug.Log("클릭");
                    Interact();
                }
            }
        }

    }
}
