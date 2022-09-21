using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runningSpeed = 10;

    public float jumpForce = 10;
    public float jumpTime = 1.0f;
    public float buttonHoldTime = 0.3f;

    public float horisontalInput;
    public bool jumping;
    public bool isOnGround;

    public float verticalInput;
    public Rigidbody2D rb;
    public WeaponController wc;
    
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

    private void Update()
    {
        JumpControl();
        wc.Shoot();
    }

    void Walk()
    //makes player walk left and right
    {
        horisontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * runningSpeed * horisontalInput);
    }

    void Jump()
    {
        //jumping
        if (Input.GetKey(KeyCode.Space) && jumping && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    void JumpControl()
    {
        //setting a jump timer for a longer jump if holding Space
        if (Input.GetKeyDown(KeyCode.Space))
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
        if (Input.GetKeyUp(KeyCode.Space) | jumpTime >= buttonHoldTime)
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
    

}
