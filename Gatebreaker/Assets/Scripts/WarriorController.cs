using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : Character
{

    float speed;

    public Animator ani;

    public Collider2D ring;


    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 0;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            speed -= moveSpeed;
            transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            speed += moveSpeed;
            transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);


        // Jumping?
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !jumping)
        {
            jumping = true;
            jumping = false;//edit this out later!
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Pow(2 * jumpHeight * rb.gravityScale * 9.81f, 0.5f));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Swing();
            ani.SetTrigger("Attack");
            ani.SetTrigger("Idle");
            
           
        }
    }
}
