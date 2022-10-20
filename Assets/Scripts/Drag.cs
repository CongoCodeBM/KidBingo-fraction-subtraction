using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    public GameObject draggedObject;

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
                            pointerData.position,
                            canvas.worldCamera,
                            out position);
        transform.position = canvas.transform.TransformPoint(position);
        draggedObject.transform.SetParent(canvas.transform);

        //draggedObject.transform.parent = canvas.transform;
        
    }
}
