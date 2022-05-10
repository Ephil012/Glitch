using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEnemies : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            BroadcastMessage("UnlockDoor");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            foreach (GameObject enemy in enemies) {
                enemy.GetComponent<EnemyCode>().paused = false;
            }
        }
    }
    
}
