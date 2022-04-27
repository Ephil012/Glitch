using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenDoor : MonoBehaviour
{

    //  private Collider2D collider;
    public GameObject lockedDoor;
    public GameObject unlockedDoor;

    // Start is called before the first frame update
    void Start()
    {
        // collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // CheckForTouch();

        // Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        // RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        // if (hit != null && hit.collider != null) {
        //     Debug.Log ("I'm hitting "+hit.collider.name);
        // }
    }

    public void PointerDown() {
        print("OpenDoor: PointerDown");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        print(other);
    }

    bool CheckForTouch()
     {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
            print(GetComponent<Collider>());
             var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
             var touchPosition = new Vector2(wp.x, wp.y);
 
            print(touchPosition + " " + Physics2D.OverlapPoint(touchPosition));
             if (GetComponent<Collider>() == Physics2D.OverlapPoint(touchPosition)){
                 Debug.Log("HIT!");
             }
             else{
                  Debug.Log("MISS");
             }
         }
         return false;
     }

    public void UnlockDoor() {
        lockedDoor.SetActive(false);
        unlockedDoor.SetActive(true);
    }
}
