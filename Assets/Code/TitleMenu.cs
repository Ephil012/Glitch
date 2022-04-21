using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("JoystickMovement");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
