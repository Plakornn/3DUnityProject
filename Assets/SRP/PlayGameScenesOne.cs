using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayGameScenesOne : MonoBehaviour
{
    public Button playButton; 

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        Debug.Log("isClick");
        PlayerPrefs.DeleteKey("Score"); 
        PlayerPrefs.DeleteKey("HP");
        SceneManager.LoadScene(1);
    }
}
