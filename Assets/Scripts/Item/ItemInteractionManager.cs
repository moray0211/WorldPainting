using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInteractionManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (!(rayhit.collider != null && rayhit.collider.GetComponent<ItemInteractionObject>() != null))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if(Object.FindObjectOfType<InventorySlotItemActive>() != null)
                    Object.FindObjectOfType<InventorySlotItemActive>().CancleAllSlotsActive();
                }
            }
        }
    }

}
