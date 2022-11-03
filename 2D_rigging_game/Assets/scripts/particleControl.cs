using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleControl : MonoBehaviour
{
    public GameObject particles;    //Makes it so I can set the object i want.
    public GameObject particlesOnFloor;



    public void spawnParticles()
    {
        GameObject particle = Instantiate(particles);                        //Insatiates(spawns) the gameobject I want (particle system).
        GameObject particleOnFloor = Instantiate(particlesOnFloor);
        Destroy(this.gameObject);                                           //Destroys the object carrying the script.
    }
}
