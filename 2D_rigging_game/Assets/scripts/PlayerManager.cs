using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Animator anim;                                       //Sets an animator I want to play with.
   

    void Start()
    {
        anim = GetComponent<Animator>();                        //The animator on the gameobject carrying this script is active.
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))                    //When the spacebar is pressed down, the animation trigger "jump" is active.
            anim.SetTrigger("jump");                 
    }

    private void OnCollisionEnter2D(Collision2D enter)      //Enables the build in Collision enter system.
    {
        if (enter.gameObject.CompareTag("rocket"))                 //Touching a GameObject with the tag "rocket" will
        {
            FindObjectOfType<GameManager>().gameLost();         //Search for the GameManager script and plays the gameLost function.      Resulting in triggering gameover
        }
    }
}
