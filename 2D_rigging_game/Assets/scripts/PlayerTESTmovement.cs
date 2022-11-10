using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerTESTmovement : MonoBehaviour
{
    bool isOnGround = false;
    bool playerFacingRight = true;
    private Rigidbody2D player;                             //The rigidbody I want to control.
    private Vector2 movement;                               //Vector2 is the same variable as movement.
    private Animator anim;                                  //The animator will be known as anim in the code.
    [SerializeField] float speed = 5f;                      //Set the speed we want to move.
    [SerializeField] float jumpForce = 10f;                  //Set the speed we want to jump.
    [SerializeField] float airSpeed = 1f;
    void Start()
    {        
        player = GetComponent<Rigidbody2D>();               //The player rigidbody is the gameobject this script is connected to.
        anim = GetComponent<Animator>();                    //The animator on the gameobject this script is connected to.
    }
    
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();                    //movement is equals to Vector2 in the Input Action system. Enables movement. 

        
        if (movement.x != 0)                //if player is moving and is on the ground the following will happen -
        {
            anim.SetFloat("x", movement.x);                 //the float x in the animator is connected to the movement.x from the Input System.
            
            anim.SetBool("isMoving", true);                 //The player is now moving and therefore, the moving animation will start.

            if (movement.x > 0 && !playerFacingRight)       //if player is moving right, but facing left -
            {
                flipPlayer();
            }

            if (movement.x < 0 && playerFacingRight)        //if player is moving left, but facing right -
            {
                flipPlayer();
            }
        }
        else
        {
            anim.SetBool("isMoving", false);                //When the player stops moving the animation will return to idle.
        }
    }
    
    void OnCollisionEnter2D(Collision2D contact)
    {
        if(contact.gameObject.tag == "ground")              //Checks to see if the player is on ground
        {
            isOnGround = true;
        }
    }


    void FixedUpdate()
    {
        if(isOnGround)
        {
            anim.SetBool("inAir", false);
            player.velocity = new Vector2(movement.x * speed, player.velocity.y);                 //Determines the player movementspeed.
        }  
        if(!isOnGround)
        {
            anim.SetBool("inAir", true);
            player.velocity = new Vector2(movement.x * airSpeed, player.velocity.y);
        }

    }

    private void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))                    //If the player is grounded and presses space - jump
        {
            anim.Play("jump");
            player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }


        if (Input.GetKeyDown(KeyCode.R))                    //Pressing R will reload the scene.
        {
            SceneManager.LoadScene(4);
            Debug.Log("You have reloaded the Scene.");
        }
    }

    private void flipPlayer()
    {
        playerFacingRight = !playerFacingRight;              //Switch players facing direction

        Vector2 playerScale = transform.localScale;         //Multiplying player scale by -1 flips player 180
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
