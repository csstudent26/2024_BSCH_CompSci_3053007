using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float maxspeed;

    public float acceleration;

    public Rigidbody2D myRb;

    public float jumpForce;

    public bool isGrounded;
    public float secondaryJumpForce;
    public float secondaryJumpTime;
    public bool secondaryJump;
    public Animator anim;

    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(myRb.velocity.x));
        // If the absolute value of the input is greater than 0.1
        if (Mathf.Abs(Input.GetAxis("Horizontal")) * acceleration > 0.1f && myRb.velocity.magnitude < maxspeed){
            
            //Gets the Input value and multiplies it by acceleration
            myRb.AddForce(new Vector2(Input.GetAxis("Horizontal") * acceleration,0),ForceMode2D.Force);
        } 
        //START JUMP CODE   
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            myRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            StartCoroutine((SecondaryJump()));
        }

        if (isGrounded == false && Input.GetButton("Jump"))
        {
            myRb.AddForce(new Vector2(0, secondaryJumpForce), ForceMode2D.Force);//While the Jump Button is held

        }
        
        //END JUMP CODE 
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        isGrounded = true;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = true;
    }

    IEnumerator SecondaryJump()
    {
        secondaryJump = true;
        yield return new WaitForSeconds(secondaryJumpTime);
        secondaryJump = false;
    }
}
