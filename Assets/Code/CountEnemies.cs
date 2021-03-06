using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    private bool broadcasted = false;
    public bool keepCollid = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void removeEnemy(GameObject enemy)
    {
        foreach (GameObject e in enemies)
        {
            if (e.GetInstanceID() == enemy.GetInstanceID())
            {
                enemies.Remove(e);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0 && broadcasted == false)
        {
            BroadcastMessage("UnlockDoor");
            if (keepCollid == false)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            broadcasted = true;
        }
    }
}
