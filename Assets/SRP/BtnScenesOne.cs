using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BtnScenesOne : MonoBehaviour
{
    public Button playButton;
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }

   private void PlayGame()
    {
        Debug.Log("isClick");
        SceneManager.LoadScene(0);
    }
}
