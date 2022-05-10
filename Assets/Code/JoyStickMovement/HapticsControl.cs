using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsControl : MonoBehaviour
{

    int bulletForce = 500;
    public GameObject bulletPrefab;
    public GameObject player;
    AudioSource _audioSource;
    public AudioClip raygunSound;
    public PuzzleInteract curPuzzle;
    public string task = "";
    private Vector2 direction;

    private Animator animator;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        animator = player.GetComponent<Animator>();
    }

     public void setPlayerDirection() {
        switch(Constants.playerDirection) {
            case "Right":
                animator.SetBool("Front_Run", false);
                animator.SetBool("Back_Run", false);
                animator.SetBool("Right_Run", true);
                animator.SetBool("Left_Run", false);
                animator.SetBool("Idle", false);
                break;
            case "Left":
                animator.SetBool("Front_Run", false);
                animator.SetBool("Back_Run", false);
                animator.SetBool("Right_Run", false);
                animator.SetBool("Left_Run", true);
                animator.SetBool("Idle", false);
                break;
            case "Back":
                animator.SetBool("Front_Run", false);
                animator.SetBool("Back_Run", true);
                animator.SetBool("Right_Run", false);
                animator.SetBool("Left_Run", false);
                animator.SetBool("Idle", false);
                break;
            case "Front":
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

    public void Vibrate() {
        GameObject newBullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);

        setPlayerDirection();

        switch(Constants.playerDirection)
        {
            case "Front":
                direction = new Vector2(0, -(bulletForce * transform.localScale.y));
                break;
            case "Back":
                direction = new Vector2(0, (bulletForce * transform.localScale.y));
                break;
            case "Left":
                direction = new Vector2(-(bulletForce * transform.localScale.x), 0);
                break;
            case "Right":
                direction = new Vector2((bulletForce * transform.localScale.x), 0);
                break;
        }

        newBullet.GetComponent<Rigidbody2D>().AddForce(direction);
        Destroy(newBullet, 1f);
        _audioSource.PlayOneShot(raygunSound);
        Handheld.Vibrate();
    }

    public void Interact()
    {
        if (curPuzzle != null && task == "puzzle") 
        {
            curPuzzle.open = true;
            Handheld.Vibrate();
        }
    }
}
