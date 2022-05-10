using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenDoor : MonoBehaviour
{

    //  private Collider2D collider;
    public GameObject lockedDoor;
    public GameObject unlockedDoor;
    public GameObject leftDoor;
    public string Level = "Room 1";

    public bool entry = false;
    public bool pausedEnemies = false;

    bool isDoorLocked = true;
    bool done = false;

    private void OnCollisionEnter2D(Collision2D other) {
        if (isDoorLocked == false && other.gameObject.tag == "Player" && entry == false) {
            Application.LoadLevel(Level);
        } else if (other.gameObject.tag == "Player" && entry == true && pausedEnemies == false) {
            UnlockDoor();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void UnlockDoor() {
        lockedDoor.SetActive(false);
        unlockedDoor.SetActive(true);
        isDoorLocked = false;

        if (!isDoorLocked) StartCoroutine(SlideDoor());
    }

    IEnumerator SlideDoor() {
        if (done == false) {
            float t = 0;
            Vector3 startLeftDoorPosition = leftDoor.transform.position;
            Vector3 startRightDoorPosition = unlockedDoor.transform.position;
            Vector3 newLeftDoorPosition = startLeftDoorPosition + new Vector3(-1, 0, 0);
            Vector3 newRightDoorPosition = startRightDoorPosition + new Vector3(1, 0, 0);

            while (t < 2)
            {
                leftDoor.transform.position = Vector2.Lerp(startLeftDoorPosition, newLeftDoorPosition, t);
                unlockedDoor.transform.position = Vector2.Lerp(startRightDoorPosition, newRightDoorPosition, t);
                t += Time.deltaTime;
                yield return null;
            }
        }
        done = true;
    }
}
