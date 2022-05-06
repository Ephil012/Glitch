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
    private bool tagChanged = false;

    public void Start()
    {
        if (actualTag.Contains("Straight") && !actualTag.Contains("plus") && !actualTag.Contains("minus"))
        {
            actualTag = "Straight";
            tagChanged = true;
        }
    }
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

        if (tagChanged)
        {
            //correct piece inserted
            if (slotObject != null && slotObject.GetComponent<RectTransform>().rotation.eulerAngles.z == actualRotation && (slotObject.tag.Contains(actualTag) && !slotObject.tag.Contains("minus") && !slotObject.tag.Contains("plus")) && !pointCheck)
            {
                pointCheck = true;
                puzzleControl.GetComponent<PuzzleInteract>().points += 1;
                Debug.Log("Correct Rotation");
            }
        }
        else
        {
            //correct piece inserted
            if (slotObject != null && slotObject.GetComponent<RectTransform>().rotation.eulerAngles.z == actualRotation && slotObject.CompareTag(actualTag) && !pointCheck)
            {
                pointCheck = true;
                puzzleControl.GetComponent<PuzzleInteract>().points += 1;
                Debug.Log("Correct Rotation");
            }
        }

        
    }
}
