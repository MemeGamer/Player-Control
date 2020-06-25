using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angry : MonoBehaviour
{
    private Animator anime;
    void Awake() {
        anime = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag=="Anger")
        {
         anime.SetBool("a",true);
         print("vvvv");
          StartCoroutine(Dead());
        }

    }

IEnumerator Dead()
    {
        
    yield return new WaitForSeconds(2f);
       anime.SetBool("a",false);
    }
}
