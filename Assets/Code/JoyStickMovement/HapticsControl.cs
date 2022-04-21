using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsControl : MonoBehaviour
{

    int bulletForce = 150;
    public GameObject bulletPrefab;
    public GameObject player;

    public void Vibrate() {
        GameObject newBullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce * transform.localScale.x, 0));
        Destroy(newBullet, 0.5f);
        Handheld.Vibrate();
    }
}
