using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInteract : MonoBehaviour
{
    public GameObject popup;
    public GameObject puzzle;
    public GameObject actionButton;
    public int points;
    public int goal;
    public bool finished = false;

    private Transform panelTransform;
    private bool hasCollided = false;
    public bool open = false;

    void Start()
    {
        popup.SetActive(false);
        puzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Beginning Puzzle
        if (open && hasCollided) //puzzle is open and player is in trigger collider
        {
            
            puzzle.SetActive(true);
            popup.SetActive(false);
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.Confined;
        }
        else if (!open && hasCollided) //puzzle is not open but player is in triggerCollider
        {
            
            puzzle.SetActive(false);
            popup.SetActive(true);
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }
        else //puzzle is open but player is not in trigger collider
        {
            puzzle.SetActive(false);
            popup.SetActive(false);
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }

        //check if puzzle is completed
        if (points == goal) 
        { 
            finished = true;
            puzzle.SetActive(false);
            popup.SetActive(false);
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
            //GameControl.control.puzzleComplete += 1;
        }

        if (Input.GetKeyDown(KeyCode.E))
        { Debug.Log("E is pressed!"); }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.transform.CompareTag("Player") && (finished == false))
        {
            Debug.Log("Play has entered!");
            actionButton.GetComponent<HapticsControl>().curPuzzle = this;
            actionButton.GetComponent<HapticsControl>().task = "puzzle";

            hasCollided = true;
            popup.GetComponent<Text>().text = "Hit E to begin tracing.";
            popup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hasCollided = false;
        popup.GetComponent<Text>().text = "";
    }
}
