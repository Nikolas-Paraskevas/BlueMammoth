using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public int levelToLoad; // The index of the level to load
    public Button button;

    private void Awake()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(levelToLoad);
        Debug.Log("Button clicked. Loading next level...");
    }

    private void Start()
    {
        Debug.Log("Awake");
    }

}

