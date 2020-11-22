using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_movement : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int MaxJumpCharge;
    public int CurrentJumpCharge;
    

    //trial
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentJumpCharge = MaxJumpCharge;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");  //get input from user, horizontals
        float moveBy = x * speed;  // multiply the input with speed 
        rb.velocity = new Vector2(moveBy, rb.velocity.y);  // set velocity of player with the moveBy variable
    }

    void Jump()
    {
         if (Input.GetKeyDown(KeyCode.Space) && CurrentJumpCharge != 0 && Time.timeScale != 0f) // allow user to jump when space is inputted, prevents jumping when no stamina
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // set velocity with jumpforce
            CurrentJumpCharge -= 1;
            if(CurrentJumpCharge <= 0){CurrentJumpCharge = 0;}
            
           
        }
        BetterJump();
        
        
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0) 
    {

        rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;

    } 
    else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) 
    {
        rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {   
        if(hitInfo.gameObject.tag != "bullets")
        {
            CurrentJumpCharge = MaxJumpCharge;
        }
    }
}
