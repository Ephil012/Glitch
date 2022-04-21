using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public JoystickControls joystickControls;
    public float playerSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (joystickControls.joystickVector.y != 0) {
            rb.velocity = new Vector2(joystickControls.joystickVector.x * playerSpeed, joystickControls.joystickVector.y * playerSpeed);
        } else {
            rb.velocity = Vector2.zero;
        }
    }
}
