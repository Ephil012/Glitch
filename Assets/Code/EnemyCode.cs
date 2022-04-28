using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCode : MonoBehaviour
{
    Animator _animator;
    Animation _animation;

    int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animation = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            _animator.SetTrigger("Death");
            Destroy(gameObject , 0.64f);
           
        }
    }
    
    public void DamageEnemy() {
        print("EnemyCode: DamageEnemy - Received Broadcast");
        health -= 20;
    }
}
