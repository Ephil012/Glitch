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

    IEnumerator WaitforAnimation() {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("Title");
    }
}
