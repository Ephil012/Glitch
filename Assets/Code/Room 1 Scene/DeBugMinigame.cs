using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBugMinigame : MonoBehaviour
{

    public GameObject bugPrefab;
    int bugMoveForce = 100;

    RectTransform panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = gameObject.GetComponent<RectTransform>();
        createBug();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createBug() {
        // Vector2 spawnPosition = new Vector2(Random.Range(0, panel.rect.x), Random.Range(0, panel.rect.y));
        Vector2 spawnPosition = new Vector2(100, 100);
        print("Debug: " + spawnPosition);
        GameObject newBug = Instantiate(bugPrefab, spawnPosition, Quaternion.identity) as GameObject;
        // newBug.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -(bugMoveForce * transform.localScale.y)));
        // newBug.transform.SetParent(gameObject.transform);
        newBug.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);

    }
}
