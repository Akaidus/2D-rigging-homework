using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void SceneLoader(int index)                  //loads scene via the build index number.
    {
        SceneManager.LoadScene(index);
        Debug.Log("You have entered the lobby.");
    }
}
