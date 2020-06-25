using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5f;
    private  Rigidbody2D mybody;
    private Animator anime;
    public Transform Gcheck;
    public LayerMask GL;

    private bool isGrounded;
    private bool jumped;

    public float jumpPower=5f;

    void Awake() {
        mybody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckifGrounded();
        Playerjump();
    }

    void FixedUpdate() {
        Playerwalk();
    }

    void Playerwalk(){
        float h = Input.GetAxisRaw("Horizontal");
        if(h>0)
        {
            ChangeDirection(0.8f);
            mybody.velocity = new Vector2(speed, mybody.velocity.y);
        }
        else if(h<0){
             ChangeDirection(-0.8f);
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
        }

        else{
             mybody.velocity = new Vector2(0f, mybody.velocity.y);
        }
        anime.SetInteger("Speed",Mathf.Abs((int)mybody.velocity.x));
        }
    void ChangeDirection(float Direction)
    {
        Vector3 dir=transform.localScale;
        dir.x=Direction;
        transform.localScale=dir;
    }
    //collision types
    /*
    }*/
   
    void CheckifGrounded()
    {
        isGrounded = Physics2D.Raycast(Gcheck.position, Vector2.down,0.1f,GL);
        if(isGrounded){
            if(jumped)
            {
                jumped= false;
                anime.SetBool("Power",false);
                anime.SetBool("Jump", false);
            }
        }
    }

    void  Playerjump()
    {
        if(isGrounded){
            if(Input.GetKey(KeyCode.Space))
            {
                jumped=true;
                anime.SetBool("Power",false);
                mybody.velocity = new Vector2(mybody.velocity.x,jumpPower);
                anime.SetBool("Jump",true);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag=="Power")
        {
         anime.SetBool("Power",true);
          StartCoroutine(Dead());
        }

    }

IEnumerator Dead()
    {
        
    yield return new WaitForSeconds(2f);
       anime.SetBool("Power",false);
    }

}//class
