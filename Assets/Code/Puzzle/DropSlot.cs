using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject puzzleControl;
    public float actualRotation;
    public string actualTag = "untagged";
    private bool pointCheck = false;

    private GameObject slotObject;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            slotObject = eventData.pointerDrag.gameObject;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && (slotObject == GameControl.currNode))
        {
            slotObject.transform.Rotate(0, 0, -90);
        }

        //correct piece inserted
        if (slotObject != null && slotObject.GetComponent<RectTransform>().rotation.eulerAngles.z == actualRotation && slotObject.tag == actualTag && !pointCheck)
        {
            pointCheck = true;
            puzzleControl.GetComponent<PuzzleInteract>().points += 1;
            Debug.Log("Correct Rotation");
        }
    }
}
