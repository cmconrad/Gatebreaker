using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{

    float speed;


    // Update is called once per frame
    void Update()
    {
        speed = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
            speed -= moveSpeed;
        transform.localScale = new Vector3(1, 1, 1);
        if (Input.GetKey(KeyCode.RightArrow))
            speed += moveSpeed;
        transform.localScale = new Vector3(-1, 1, 1);

        rb.velocity = new Vector2(speed, rb.velocity.y);


        // Jumping?
        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumping)
        {
            jumping = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Pow(2 * jumpHeight * rb.gravityScale * 9.81f, 0.5f));
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Swing();
        }
    }
}
