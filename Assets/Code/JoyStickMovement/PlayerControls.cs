using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public JoystickControls joystickControls;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Constants.playerDirection = "Back";
    }

    void FixedUpdate()
    {
        if (joystickControls.joystickVector.y != 0 || joystickControls.joystickVector.x != 0) {
            if (Mathf.Abs(joystickControls.joystickVector.x) > Mathf.Abs(joystickControls.joystickVector.y)) {
                if (joystickControls.joystickVector.x > 0) {
                    animator.SetBool("Front_Run", false);
                    animator.SetBool("Back_Run", false);
                    animator.SetBool("Right_Run", true);
                    animator.SetBool("Left_Run", false);
                    animator.SetBool("Idle", false);
                    Constants.playerDirection = "Right";
                } else {
                    animator.SetBool("Front_Run", false);
                    animator.SetBool("Back_Run", false);
                    animator.SetBool("Right_Run", false);
                    animator.SetBool("Left_Run", true);
                    animator.SetBool("Idle", false);
                    Constants.playerDirection = "Left";
                }
            } else {
                if (joystickControls.joystickVector.y > 0) {
                    animator.SetBool("Front_Run", false);
                    animator.SetBool("Back_Run", true);
                    animator.SetBool("Right_Run", false);
                    animator.SetBool("Left_Run", false);
                    animator.SetBool("Idle", false);
                    Constants.playerDirection = "Back";
                } else {
                    animator.SetBool("Front_Run", true);
                    animator.SetBool("Back_Run", false);
                    animator.SetBool("Right_Run", false);
                    animator.SetBool("Left_Run", false);
                    animator.SetBool("Idle", false);
                    Constants.playerDirection = "Front";
                }
            }
            rb.velocity = new Vector2(joystickControls.joystickVector.x * playerSpeed, joystickControls.joystickVector.y * playerSpeed);
        } else {
            rb.velocity = Vector2.zero;
            animator.SetBool("Front_Run", false);
            animator.SetBool("Back_Run", false);
            animator.SetBool("Right_Run", false);
            animator.SetBool("Left_Run", false);
            animator.SetBool("Idle", true);
        }
    }
}
