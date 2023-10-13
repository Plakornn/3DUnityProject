using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameScenesOne : MonoBehaviour
{
    IEnumerator OnMouseDown()
    {
        yield return new WaitForSeconds(0f);
        Debug.Log("isClick");
        SceneManager.LoadScene("scene1");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
