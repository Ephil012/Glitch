using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public int puzzleComplete = 0;
    public static GameObject currNode;
    public bool win = false;

    void Awake()
    {
        if (control == null)        // If this is the first scene...
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)   // For any subsequent scene that uses GameControl...
        {       // If I am the new instance of the GameControl script...
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (puzzleComplete == 4)
        {
            win = true;
        }
    }
}
