using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class EnemyCode : MonoBehaviour
{
    Animator _animator;
    Animation _animation;

    Rigidbody2D _rigidBody;
    GameObject player;
    SpriteRenderer playerSprite;

    SpriteRenderer currentEnemySprite;

    public GameObject door;

    private Vector2 playerTarget;
    float speed = 0.5f;

    int health = 100;

    public int decrement = 20;

    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animation = gameObject.GetComponent<Animation>();

        player = GameObject.FindGameObjectWithTag("Player");
        _rigidBody = this.GetComponent<Rigidbody2D>();

        playerSprite = player.GetComponent<SpriteRenderer>();
        currentEnemySprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            _animator.SetTrigger("Death");
            Destroy(gameObject , 0.64f);
            if (door != null) {
                door.BroadcastMessage("removeEnemy", gameObject);
            }
        }

        if (paused == false) {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            playerTarget = direction;
        }
    }

    void FixedUpdate()
    {  
        if (paused == false) {
            _rigidBody.MovePosition((Vector2)transform.position + (playerTarget * speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet") {
            DamageEnemy();
            StartCoroutine(EnemyFlashRed());
        } else if (other.gameObject.tag == "Player") {
            print("Enemy Hit Player");
            PublicVars.DealDamage();
            StartCoroutine(PlayerFlashRed());
        }
    }

    public void DamageEnemy() {
        print("EnemyCode: DamageEnemy - Received Broadcast");
        health -= decrement;
    }

    IEnumerator PlayerFlashRed() {
        playerSprite.color = new Color(1f, 0.61f, 0.61f, 1f);
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = Color.white;
    }

    IEnumerator EnemyFlashRed() {
        currentEnemySprite.color = new Color(1f, 0.61f, 0.61f, 1f);
        yield return new WaitForSeconds(0.2f);
        currentEnemySprite.color = Color.white;
    }


}
