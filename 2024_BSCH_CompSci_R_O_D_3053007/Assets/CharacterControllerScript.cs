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
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the absolute value of the input is greater than 0.1
        if (Mathf.Abs(Input.GetAxis("Horizontal")) * acceleration > 0.1f && myRb.velocity.magnitude < maxspeed){
            
            //Gets the Input value and multiplies it by acceleration
            myRb.AddForce(new Vector2(Input.GetAxis("Horizontal") * acceleration,0),ForceMode2D.Force);
        }
    }
}
