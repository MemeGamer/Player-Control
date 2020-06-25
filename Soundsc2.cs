using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundsc2 : MonoBehaviour
{
  private AudioSource audioManager;
     void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Update()
    {

        PlayerShoot();
    }
   void  PlayerShoot()
    {
            if(Input.GetKeyDown(KeyCode.F))
            {
                audioManager.Play();
            }
        }
}
