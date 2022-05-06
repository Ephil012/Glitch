using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBugMinigameTrigger : MonoBehaviour
{

    public GameObject DeBugMinigameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            print("DebUgTrigger Hit Player");
            DeBugMinigameObject.SetActive(true);
        }
    }
}
