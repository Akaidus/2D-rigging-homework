using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRockets : MonoBehaviour
{
    public GameObject rocketPrefab;            //Makes a prefab selectable.
    public float spawnrate = 1.0f;        //Sets spawnrate of rockets
                                          

    public void spawnRocketStart()
    {
        StartCoroutine(spawnrateRocket());     //Executes the IEnumerator.
    }
    private void spawnRocket()
    {
        GameObject a = Instantiate(rocketPrefab) as GameObject;    //Spawns the prefab as a GameObject.
        a.transform.position = new Vector2(11, -3.17f);          //Where the prefab spawns.

    }
    IEnumerator spawnrateRocket()
    {
        while (true)                                            //Loops the IEnumerator
        {
            yield return new WaitForSeconds(spawnrate);       //waits for the spawn time to execute "spawnRocket" function.
            spawnRocket();
        }
    }
}
