using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;

    private bool Boom;
    
    private Animator anim;
    // Start is called before the first frame update
     void Awake() {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(DisableBullet(5f));
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }
    void Move(){
        Vector3 temp = transform.position;
        temp.x += Speed * Time.deltaTime;
        transform.position=temp;
    }

    public float Speed{
        get{
            return speed;
        }
        set{
            speed = value;
        }
    }

    void exp()
    {
        {
        Boom=true;
        anim.Play("Explode");
        }
    }

    IEnumerator DisableBullet(float timer)
    {
          exp();
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

   void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.tag =="Beetal"||target.gameObject.tag =="snail"||target.gameObject.tag =="Boss")
        {   
            gameObject.SetActive(false);
           
        }
    }
}//class

