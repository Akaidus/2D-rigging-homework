using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool gameover = false;                                          //The gameover state is false
    [SerializeField] float delayTime = 2f;                          //set time delay.
    public GameObject gameoverScreen;                               //makes the gameoverScreen accessable by the script.
    public GameObject kaboom;                                      //Makes a prefab selectable.
                                         
    public void gameLost()
    {
        if (gameover == false)                                      //if the gameover bool is false - run the function.
            gameover = true;
            Destroy(GameObject.Find("Player"));                    //searches for a gameobject named "Player" and destroys it.
            GameObject a = Instantiate(kaboom) as GameObject;           //Spawns the prefab as a GameObject.
            a.transform.position = new Vector2(0.5f, -2.62f);          //Where the prefab spawns.
            Invoke("GameoverOne", delayTime);                       //calls the public void GameoverOne with a time delay.
            Debug.Log("You died");
        
    }

    public void GameoverOne()
    {
        gameoverScreen.SetActive(true);                         //enables the gameoverScreen, so it becomes visable.
        Invoke("GameoverScene", delayTime);
    }
    public void GameoverScene()
    {
        SceneManager.LoadScene(2);
        Debug.Log("You have died.");
    }

    public void RestartGameScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("You are retrying the Jumping Mini Game.");
    }
}
