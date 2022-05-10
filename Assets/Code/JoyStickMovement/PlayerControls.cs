using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Update() {
        if (PublicVars.health <= 0) {
            PublicVars.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        if (joystickControls.joystickVector.y != 0 || joystickControls.joystickVector.x != 0) {
            if (Mathf.Abs(joystickControls.joystickVector.x) > Mathf.Abs(joystickControls.joystickVector.y)) {
                if (joystickControls.joystickVector.x > 0) {
                    Constants.playerDirection = "Right";
                    animator.SetBool("Front_Run", false);
                    animator.SetBool("Back_Run", false);
                    animator.SetBool("Right_Run", true);
                    animator.SetBool("Left_Run", false);
                    animator.SetBool("Idle", false);
                } else {
                    Constants.playerDirection = "Left";
                    animator.SetBool("Front_Run", false);
                    animator.SetBool("Back_Run", false);
                    animator.SetBool("Right_Run", false);
                    animator.SetBool("Left_Run", true);
                    animator.SetBool("Idle", false);
                }
            } else {
                if (joystickControls.joystickVector.y > 0) {
                    Constants.playerDirection = "Back";
                    animator.SetBool("Front_Run", false);
                    animator.SetBool("Back_Run", true);
                    animator.SetBool("Right_Run", false);
                    animator.SetBool("Left_Run", false);
                    animator.SetBool("Idle", false);
                } else {
                    Constants.playerDirection = "Front";
                    animator.SetBool("Front_Run", true);
                    animator.SetBool("Back_Run", false);
                    animator.SetBool("Right_Run", false);
                    animator.SetBool("Left_Run", false);
                    animator.SetBool("Idle", false);
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
