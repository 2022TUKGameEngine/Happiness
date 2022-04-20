using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Vector2 lastMousePosition;
    public RectTransform rect;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition=eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff=currentMousePosition-lastMousePosition;

        Vector3 newPosition=rect.position+new Vector3(diff.x, diff.y, transform.position.z);
        
        rect.position = newPosition;
        
        lastMousePosition=currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }

    public void ResetPos()
    {
        Vector3 DefaultPosition=new Vector3(Screen.width/2, Screen.height/2,0);
        rect.position=DefaultPosition;
    }


}
