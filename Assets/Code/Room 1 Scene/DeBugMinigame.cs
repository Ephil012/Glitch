using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBugMinigame : MonoBehaviour
{

    public GameObject bugPrefab;
    int bugMoveForce = 100;

    int score = 0;

    RectTransform panel;

    public Collider2D collider;

    public GameObject TopDoor;


    // Start is called before the first frame update
    void Start()
    {
        panel = gameObject.GetComponent<RectTransform>();
        StartCoroutine(bugGame());
    }

    // Update is called once per frame
    void Update()
    {
        // CheckForTouch();

        if (score > 2) {
            print("DeBugMinigame: Score > 10. Found 10 Bugs");
            gameObject.SetActive(false);
            TopDoor.BroadcastMessage("UnlockDoor");
        }
    }

    IEnumerator bugGame()
    {
        int i;
        for (i = 0; i < 10; i++) {
            createBug();
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    void createBug() {
        Vector2 spawnPosition = new Vector2(Random.Range(0, 1792), Random.Range(0, 828));
        // Vector2 spawnPosition = new Vector2(1000, 500);
        // print("Debug: " + spawnPosition);

        GameObject newBug = GameObject.Instantiate(bugPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
        // GameObject newBug = Instantiate(bugPrefab, spawnPosition, Quaternion.identity) as GameObject;
        
        newBug.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -(bugMoveForce * transform.localScale.y)));
        
        // newBug.transform.SetParent(gameObject.transform);
        // newBug.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    bool CheckForTouch()
     {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
            print(collider);
             var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
             var touchPosition = new Vector2(wp.x, wp.y);
 
            print(Physics2D.OverlapPoint(touchPosition));
             if (collider == Physics2D.OverlapPoint(touchPosition)){
                 Debug.Log("HIT!");
             }
             else{
                  Debug.Log("MISS");
             }
         }
         return false;
     }

    public void ClickedOnBug() {
        print("DeBugMinigame: Clicked on Bug");
        score += 1;
    }
}
