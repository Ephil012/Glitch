using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCode : MonoBehaviour
{

    int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void DamageEnemy() {
        print("EnemyCode: DamageEnemy - Received Broadcast");
        health -= 20;
    }
}
