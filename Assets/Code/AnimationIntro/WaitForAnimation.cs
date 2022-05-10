using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForAnimation : MonoBehaviour
{

    public float timeToWait = 12f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitforAnimation());    
    }

    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene("Title");
        }
    }

    IEnumerator WaitforAnimation() {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("Title");
    }
}
