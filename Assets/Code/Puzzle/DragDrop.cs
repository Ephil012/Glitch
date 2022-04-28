using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rect;
    private CanvasGroup cGroup;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        cGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begins");
        cGroup.alpha = 0.6f;
        cGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
        cGroup.alpha = 1f;
        cGroup.blocksRaycasts = true;
        GameControl.currNode = eventData.pointerDrag.gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("PointerIsDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Dropped");
    }
}
