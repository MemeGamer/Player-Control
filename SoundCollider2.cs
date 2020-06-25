using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider2 : MonoBehaviour
{
    private AudioSource audioManager;
   void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Player")
        {
            audioManager.Play();
            StartCoroutine(DisableBullet(8f));
        }
    }

     IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}