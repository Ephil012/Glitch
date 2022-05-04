using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCode : MonoBehaviour
{
    Animator _animator;
    Animation _animation;

    Rigidbody2D _rigidBody;
    GameObject player;

    private Vector2 playerTarget;
    float speed = 0.5f;

    int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animation = gameObject.GetComponent<Animation>();

        player = GameObject.FindGameObjectWithTag("Player");
        _rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            _animator.SetTrigger("Death");
            Destroy(gameObject , 0.64f);
        }

        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rigidBody .rotation = angle;
        direction.Normalize();
        playerTarget = direction;
    }

    void FixedUpdate()
    {  
        _rigidBody.MovePosition((Vector2)transform.position + (playerTarget * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet") {
            DamageEnemy();
        } else if (other.gameObject.tag == "Player") {
            print("Enemy Hit Player");
            PublicVars.DealDamage();
        }
    }
    public void DamageEnemy() {
        print("EnemyCode: DamageEnemy - Received Broadcast");
        health -= 20;
    }
}
