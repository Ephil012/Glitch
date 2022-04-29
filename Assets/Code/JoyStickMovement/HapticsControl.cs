using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsControl : MonoBehaviour
{

    int bulletForce = 500;
    public GameObject bulletPrefab;
    public GameObject player;
    AudioSource _audioSource;
    public AudioClip raygunSound;
    public PuzzleInteract curPuzzle;
    public string task = "";
    private Vector2 direction;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Vibrate() {
        GameObject newBullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);

        switch(Constants.playerDirection)
        {
            case "Front":
                direction = new Vector2(0, -(bulletForce * transform.localScale.y));
                break;
            case "Back":
                direction = new Vector2(0, (bulletForce * transform.localScale.y));
                break;
            case "Left":
                direction = new Vector2(-(bulletForce * transform.localScale.x), 0);
                break;
            case "Right":
                direction = new Vector2((bulletForce * transform.localScale.x), 0);
                break;
        }

        newBullet.GetComponent<Rigidbody2D>().AddForce(direction);
        Destroy(newBullet, 0.5f);
        _audioSource.PlayOneShot(raygunSound);
        Handheld.Vibrate();
    }

    public void Interact()
    {
        if (curPuzzle != null && task == "puzzle") 
        {
            curPuzzle.open = true;
            Handheld.Vibrate();
        }
    }
}
