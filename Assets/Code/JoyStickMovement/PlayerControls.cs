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

    SpriteRenderer playerSprite;

    private bool death;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        death = false;
        Constants.playerDirection = "Back";
    }

    IEnumerator Die()
    {
        animator.Play("Front_Death");
        yield return new WaitForSeconds(0.4f);
        PublicVars.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update() {
        if (PublicVars.health <= 0) {
            if (death == false) {
                death = true;
                StartCoroutine(Die());
            }
        }
    }

    public void PlayerHit() {
        print("Enemy Hit Player");
        PublicVars.DealDamage();
        StartCoroutine(PlayerFlashRed());
    }

    IEnumerator PlayerFlashRed() {
        playerSprite.color = new Color(1f, 0.61f, 0.61f, 1f);
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = Color.white;
    }

    public void setPlayerDirection(string direction) {
        switch(direction) {
            case "Right":
                Constants.playerDirection = "Right";
                animator.SetBool("Front_Run", false);
                animator.SetBool("Back_Run", false);
                animator.SetBool("Right_Run", true);
                animator.SetBool("Left_Run", false);
                animator.SetBool("Idle", false);
                break;
            case "Left":
                Constants.playerDirection = "Left";
                animator.SetBool("Front_Run", false);
                animator.SetBool("Back_Run", false);
                animator.SetBool("Right_Run", false);
                animator.SetBool("Left_Run", true);
                animator.SetBool("Idle", false);
                break;
            case "Back":
                Constants.playerDirection = "Back";
                animator.SetBool("Front_Run", false);
                animator.SetBool("Back_Run", true);
                animator.SetBool("Right_Run", false);
                animator.SetBool("Left_Run", false);
                animator.SetBool("Idle", false);
                break;
            case "Front":
                Constants.playerDirection = "Front";
                animator.SetBool("Front_Run", true);
                animator.SetBool("Back_Run", false);
                animator.SetBool("Right_Run", false);
                animator.SetBool("Left_Run", false);
                animator.SetBool("Idle", false);
                break;
            case "Idle":
                animator.SetBool("Front_Run", false);
                animator.SetBool("Back_Run", false);
                animator.SetBool("Right_Run", false);
                animator.SetBool("Left_Run", false);
                animator.SetBool("Idle", true);
                break;
        }
    }

    void FixedUpdate()
    {
        if (PublicVars.health >= 0) {
            if (joystickControls.joystickVector.y != 0 || joystickControls.joystickVector.x != 0) {
                if (Mathf.Abs(joystickControls.joystickVector.x) > Mathf.Abs(joystickControls.joystickVector.y)) {
                    if (joystickControls.joystickVector.x > 0) {
                        setPlayerDirection("Right");
                    } else {
                        setPlayerDirection("Left");
                    }
                } else {
                    if (joystickControls.joystickVector.y > 0) {
                        setPlayerDirection("Back");
                    } else {
                        setPlayerDirection("Front");
                    }
                }
                rb.velocity = new Vector2(joystickControls.joystickVector.x * playerSpeed, joystickControls.joystickVector.y * playerSpeed);
            } else {
                rb.velocity = Vector2.zero;
                setPlayerDirection("Idle");
            }
        }
    }
}
