using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class rocketMove : MonoBehaviour
{
    

    public float speed = 10.0f;                     //Sets the speed of the box.
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();      //The box is verified as a Rigidbody2D.
        rb.velocity = new Vector2(-speed, 0);       //Moves box a constant rate on the x axis, in this case to the left.

    }

    private void OnCollisionEnter2D(Collision2D enter)      //Enables the build in Collision enter system.
    {
        if (enter.gameObject.CompareTag("Player"))                 //Touching a GameObject with the tag "Player" will
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {   
        if (transform.position.x < -15)             //When the box's x postion is greater than the value given - destroy the box.
        {
            Destroy(this.gameObject);
        }
    }   
}
