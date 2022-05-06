using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour {

    AudioSource _audioSource;
    public AudioClip healthupSound;
    
    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            print("HealthBoost Touching Player");
            PublicVars.BoostHealth();
            StartCoroutine(CollectPowerup());
        }
    }

    IEnumerator CollectPowerup()
    {
        _audioSource.PlayOneShot(healthupSound);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield return null;
    }
}
