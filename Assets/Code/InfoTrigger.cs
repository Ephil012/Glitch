using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTrigger : MonoBehaviour
{

    public GameObject dialogueBox;
    public Sprite openedChest;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("InfoTrigger: touching" +  other.gameObject.tag);
        if (other.gameObject.tag == "Player") {
            dialogueBox.SetActive(true);
            dialogueBox.BroadcastMessage("PrecheckDialogue");
            // dialogueBox.GetComponent<Dialogue>().ActivateDialogue(ChangeChestSpriteCallback);
        }
    }

    public void ChangeChestSprite() {
        print("InfoTrigger: Received Broadcast");
        gameObject.GetComponent<SpriteRenderer>().sprite = openedChest;
    }
}
