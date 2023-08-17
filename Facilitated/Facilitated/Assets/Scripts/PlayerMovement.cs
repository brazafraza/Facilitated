using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //movement speed and drag
    public float moveSpeed;
    public float groundDrag;

    //jump force, jump cooldown, speed multiplier in the air 
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    //if the player is ready to jump
    bool readyToJump;

    //jump keybind
        public KeyCode jumpKey = KeyCode.Space;

   //ground check variables
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    //player orientation and inputs
    public Transform orientation;
    float horizontalInput;
    float vertcialInput;

    //movement direction 
    Vector3 moveDirection;

    //rigidbody being referenced
    Rigidbody rb;

    private void Start()
    {

        readyToJump = true;
        //assign rigidbody and make sure doesnt fall over 
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //ground check for beanbag
        if (tag == "Beanbag")
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
            
        }

       // ground check for beanbag
        if (tag == "Harvard")
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 1f + 0.4f, whatIsGround);
        }

        //calling player input and speed values
        MyInput();
        SpeedControl();

        //drag only if grounded
        if (grounded)
        {
            rb.drag = groundDrag;
           // Debug.Log("is grounded");
        }
        else
        {
            rb.drag = 0;
        }   
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        vertcialInput = Input.GetAxisRaw("Vertical");

        //when can jump
        if (Input.GetKey(jumpKey) && grounded && readyToJump)
        {
            readyToJump = false;

            Jump();
            //resetting jump function after cooldown
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //calculating movement direction 
        moveDirection = orientation.forward * vertcialInput + orientation.right * horizontalInput;


        //movement on ground
        if (grounded)
        {
            //move player in calculated direction
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //movement in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //calculating max speed and applying (limiting speed) if player speed exceeds
        if(flatVel.magnitude > moveSpeed)
        {
           
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //reset y velo so player always jumps same heigh
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        //setting jump to true so player can jump again
        readyToJump = true;
    }

}
