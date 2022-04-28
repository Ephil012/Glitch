using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCode : MonoBehaviour
{

    GameObject parentMinigame;

    // Start is called before the first frame update
    void Start()
    {
        parentMinigame = transform.parent.gameObject;
        print(parentMinigame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBugClick() {
        print("BugCode: Clicked on Bug");
        parentMinigame.BroadcastMessage("ClickedOnBug");
        Destroy(gameObject);
    }
}
