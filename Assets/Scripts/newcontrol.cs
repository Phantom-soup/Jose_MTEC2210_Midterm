using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcontrol : MonoBehaviour
{
    public float speed = 15;
    public float jumpPower = 10;
    public float rayDist = 0.6f;
    private Rigidbody2D rb;

    bool jumpFlag = false;
    float xMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        xMove = Input.GetAxisRaw("Horizontal");
        

        if (Grounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpFlag = true;
            }
        }
    }

    private bool Grounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayDist, LayerMask.GetMask("ground"));
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (jumpFlag)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpFlag = false;
        }
    }
}
