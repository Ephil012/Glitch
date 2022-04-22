using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private int health = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet") {
            health -= 5;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
