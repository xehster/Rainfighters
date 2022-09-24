using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Action OnGetHit;
    public float runningSpeed = 10;

    public float jumpForce = 10;
    public float jumpTime = 1.0f;
    public float buttonHoldTime = 0.3f;

    public float horisontalInput;
    public bool jumping;
    public bool isOnGround;
    public bool lookingLeft;

    public float verticalInput;
    public Rigidbody2D rb;
    public WeaponController wc;

    public KeyCode JumpButton;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        Walk();
    }
    
    public void HitByRay()
    {
        OnGetHit.Invoke();
    }


    private void Update()
    {
        JumpControl();
        wc.Shoot();
        AnimUpdate();
    }

    void Walk()
    //makes player walk left and right
    {
        horisontalInput = Input.GetAxis("Horizontal");
        

        if (horisontalInput < 0f && lookingLeft == false)
        {
            transform.Rotate(0f, 180f, 0f);
            lookingLeft = true;

        }
        else if(horisontalInput > 0f && lookingLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            lookingLeft = false;

        }


        if (lookingLeft == false)
        {
            transform.Translate(Vector2.right * Time.deltaTime * runningSpeed * horisontalInput); 
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * runningSpeed * -horisontalInput);
        }
    }

    void Jump()
    {
        //jumping
        if (Input.GetKey(KeyCode.W) && jumping && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    void JumpControl()
    {
        //setting a jump timer for a longer jump if holding Space
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumping = true;
            jumpTime = 0;

        }
        //starting jump timer
        if (jumping)
        {
            jumpTime += Time.deltaTime;
        }

        //stopping jump timer
        if (Input.GetKeyUp(KeyCode.W) | jumpTime >= buttonHoldTime)
        {
            jumping = false;
        }

    }

    //checking if player is on ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SolidGround"))
        {
            isOnGround = true;
        }
    }

    //checking if player is not on ground
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SolidGround"))
        {
            isOnGround = false;
        }
    }

    void AnimUpdate()
    {
        horisontalInput = Input.GetAxis("Horizontal");
        
        //running animation state = 1
        //idle animation state = 0
        if (horisontalInput == 0)
        {
            anim.SetInteger("animState",0);

        }
        else
        {
            anim.SetInteger("animState",1);
        }
        
        //jumping animation state = 2
        if (rb.velocity.y > 0.0f)
        {
            anim.SetInteger("animState", 2);
        }
        //falling animation state = 3
        else if (rb.velocity.y < 0.0f)
        {
            anim.SetInteger("animState", 3);
        }


    }
    
    

}
