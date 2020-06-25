using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text coinTextScore;
    private AudioSource audioManager;

    private int scorecount;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Coin")
        {

            target.gameObject.SetActive(false);
            scorecount++;
            coinTextScore.text = "x" + scorecount;
            
            audioManager.Play();
        }
        else if(target.tag== "C1")
            {
                scorecount=200;
               coinTextScore.text = "x" + scorecount; 
            }
    }
}
