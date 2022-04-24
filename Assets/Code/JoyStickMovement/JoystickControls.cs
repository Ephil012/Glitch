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
    private Vector2 joystickBackgroundStartPosition;
    private float joystickRadius;
    
    void Start()
    {
        joystickStartPosition = joystick.transform.position;
        joystickBackgroundStartPosition = joystickBackground.transform.position;
        joystickRadius = joystickBackground.GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    public void PointerDown() {
        float joystickDist = Vector2.Distance(Input.mousePosition, joystickStartPosition);

        if (joystickDist < joystickRadius) {
            joystick.transform.position = joystickStartPosition + joystickVector * joystickDist;
        } else {
            joystick.transform.position = joystickStartPosition + joystickVector * joystickRadius;
        }
    }

    public void Drag(BaseEventData baseEventData) {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVector = (dragPos - joystickStartPosition).normalized;
        
        float joystickDist = Vector2.Distance(dragPos, joystickStartPosition);

        if (joystickDist < joystickRadius) {
            joystick.transform.position = joystickStartPosition + joystickVector * joystickDist;
        } else {
            joystick.transform.position = joystickStartPosition + joystickVector * joystickRadius;
        }
    }

    public void PointerUp() {
        joystickVector = Vector2.zero;
        joystick.transform.position = joystickStartPosition;
        joystickBackground.transform.position = joystickBackgroundStartPosition;
    }

}
