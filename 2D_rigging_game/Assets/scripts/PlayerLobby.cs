using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerLobby : MonoBehaviour
{
    private Rigidbody2D player;                             //The rigidbody I want to control.
    private Vector2 movement;                               //Vector2 is the same variable as movement.
    private Animator anim;                                  //The animator will be known as anim in the code.
    [SerializeField] float speed = 5f;                      //Set the speed we want to move.

    void Start()
    {
        player = GetComponent<Rigidbody2D>();               //The player rigidbody is the gameobject this script is connected to.
        anim = GetComponent<Animator>();                    //The animator on the gameobject this script is connected to.
    }
        
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();                    //movement is equals to Vector2 in the Input Action system. Enables movement. 

        
        if (movement.x != 0 || movement.y != 0)             //As long as the Vector2's x and y value is not = [0,0] the following will happen -
        {
            anim.SetFloat("x", movement.x);                 //the float x in the animator is connected to the movement.x from the Input System.
            anim.SetFloat("y", movement.y);                 //the float y in the animator is connected to the movement.y from the Input System.

            anim.SetBool("isMoving", true);                 //The player is now moving and therefore, the moving animation will start.
        }
        else
        {
            anim.SetBool("isMoving", false);                //When the player stops moving the animation will return to idle.
        }
        
    }

    void FixedUpdate()
    {
        player.velocity = movement * speed;                 //Determines the player movementspeed.
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))                    //Pressing R will reload the scene.
        {
            SceneManager.LoadScene(0);
            Debug.Log("You have reloaded the Lobby.");
        }
    }


    private void OnCollisionEnter2D(Collision2D enter)      //Enables the build in Collision enter system
    {
        if (enter.gameObject.CompareTag("anima"))                   //touching a GameObject with the tag "anima" will load scene 3 (the animation scene)
        {
            SceneManager.LoadScene(3);
            Debug.Log("You have entered the Animation Level.");
        }

        if (enter.gameObject.CompareTag("jmg"))                             //touching a GameObject with the tag "jmg" will load scene 0 (the jumping mini game scene)
        {
            SceneManager.LoadScene(1);
            Debug.Log("You have entered the Jumping Mini Game Level.");
        }

    }
}
