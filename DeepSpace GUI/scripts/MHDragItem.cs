using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class MHDragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Register that drag have started. So that other objects may check this status in case they need to behave differently
    static public bool dragActive = false;    

    RectTransform draggingPlane;
    Vector3 dragOffset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            return;        
                
        transform.SetAsLastSibling();
        draggingPlane = canvas.transform as RectTransform;

        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingPlane, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            dragOffset = globalMousePos - transform.TransformPoint(Vector3.zero);
        }
        else
        {
            dragOffset = Vector3.zero;
        }

        SetDraggedPosition(eventData);

        dragActive = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingPlane, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos - dragOffset;
            rt.rotation = draggingPlane.rotation;
        }
    }

    public void OnEndDrag(PointerEventData e)
    {       
        dragActive = false;
    }
}
