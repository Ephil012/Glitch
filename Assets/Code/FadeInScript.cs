using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    public Color startClr;
    public Color endClr;
    public Texture fadeTexture;
    public float fadeLength = 15.0f;
    private Color curClr;
    private float t = 0;

    void Start()
    {
        startClr = new Color(0f, 0f, 0f, 1f);
        endClr = new Color(0f, 0f, 0f, 0f);
        curClr = startClr;
        Destroy(gameObject, fadeLength + 1.0f);
    }

    void Update()
    {
        if (t < 1)
        {
            t += Time.deltaTime / fadeLength;
            curClr = Color.Lerp(startClr, endClr, t);
        }
    }

    private void OnGUI()
    {
        GUI.color = curClr;
        GUI.depth = -10;
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), fadeTexture);
    }
}
