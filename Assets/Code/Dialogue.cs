using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public GameObject infoComputer;
    public TextMeshProUGUI textBox;
    public string[] lines;
    public float textSpeed;
    bool hasOpened = false;
    public GameObject Door;
    int index;

    AudioSource _audioSource;

    public void PrecheckDialogue() {
        print("Dialogue: PrecheckDialogue");
        if (!hasOpened) {
            textBox.text = string.Empty;
            StartDialogue();
        } else {
            textBox.text = string.Empty;
            // StartDialogue();
            gameObject.SetActive(false);
        }
    }

    void Awake() {
        print("Dialogue: Awake");
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Dialogue: Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) { // TODO: Change this to mobile screen touch
            if (textBox.text == lines[index]) {
                NextLine();
            } else {
                StopAllCoroutines();
                _audioSource.Stop();
                textBox.text = lines[index];
            }
        }
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeOut());
    }

    IEnumerator TypeOut() {
        _audioSource.Play();
        foreach (char c in lines[index].ToCharArray()) {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        _audioSource.Stop();
    }

    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textBox.text = string.Empty;
            StartCoroutine(TypeOut());
        } else {
            // BroadcastMessage("ChangeChestSpriteCallback");
            infoComputer.BroadcastMessage("ChangeChestSprite");
            hasOpened = true;
            gameObject.SetActive(false);
            Door.BroadcastMessage("UnlockDoor");
        }
    }
}
