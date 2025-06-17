using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public int levelToLoad; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);

            Debug.Log("Player entered the trigger area. Loading next level...");
        }
    }
}

