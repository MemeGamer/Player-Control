using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private Text coinTextScore;
    private int scorecount;
    private bool canDamage;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        coinTextScore = GameObject.Find("LifeText").GetComponent<Text>();
        scorecount = 3;
        coinTextScore.text = "x" + scorecount;

        canDamage = true;
    }
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Time.timeScale = 1f;
    }
    public void DealDamage(){
        if(canDamage)
        {
        scorecount--;
        if(scorecount>=0)
        {
            coinTextScore.text = "x" + scorecount;
        }

        if(scorecount == 0)
        {
            Time.timeScale = 0f;
            StartCoroutine(RestartGame());
        }

        canDamage = false;
        StartCoroutine(WaitForDamage());
        }
    }
    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Power")
        {
            if(scorecount==1)
            {
            scorecount=scorecount+2;
            coinTextScore.text = "x" + scorecount;
            target.gameObject.SetActive(false);
            }
            else
            {
            scorecount=scorecount+1;
            coinTextScore.text = "x" + scorecount;
            target.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator  WaitForDamage()
    {
    yield return new WaitForSeconds(2f);
    canDamage = true;
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("SampleScene");
    }

}
