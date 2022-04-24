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

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Vibrate() {
        GameObject newBullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -(bulletForce * transform.localScale.y)));
        Destroy(newBullet, 0.5f);
        _audioSource.PlayOneShot(raygunSound);
        Handheld.Vibrate();
    }
}
