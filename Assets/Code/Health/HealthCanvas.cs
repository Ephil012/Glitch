using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthCanvas : MonoBehaviour
{
    public Image[] hearts;

    public Sprite emptyHeart;
    public Sprite fullHeart;

    void Start()
    {
        
    }

    void Update()
    {
        int numOfFullHearts = (PublicVars.health * hearts.Length) / 100;
        for (int i = 0; i < hearts.Length; i++) {
            if (i < numOfFullHearts + 1) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
