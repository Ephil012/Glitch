using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickControls : MonoBehaviour
{

    public GameObject joystick;
    public GameObject joystickBackground;
    public Vector2 joystickVector;
    private Vector2 joystickTouchPos;
    private Vector2 joystickStartPosition;
    private float joystickRadius;
    
    void Start()
    {
        joystickStartPosition = joystickBackground.transform.position;
        joystickRadius = joystickBackground.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void PointerDown() {
        joystick.SetActive(true);
        joystickBackground.SetActive(true);
        joystick.transform.position = Input.mousePosition;
        joystickBackground.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
        // print(joystickTouchPos);
    }

    public void Drag(BaseEventData baseEventData) {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVector = (dragPos - joystickTouchPos).normalized;
        
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius) {
            joystick.transform.position = joystickTouchPos + joystickVector * joystickDist;
        } else {
            joystick.transform.position = joystickTouchPos + joystickVector * joystickRadius;
        }
    }

    public void PointerUp() {
        joystick.SetActive(false);
        joystickBackground.SetActive(false);
        joystickVector = Vector2.zero;
        joystick.transform.position = joystickStartPosition;
        joystickBackground.transform.position = joystickStartPosition;
    }

}
