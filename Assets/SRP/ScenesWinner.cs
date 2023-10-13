using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesWinner : MonoBehaviour
{
    
    private int Win;

    void Start ()
    {
        Win = SceneManager.GetActiveScene().buildIndex + 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(4);
        }
    }
}
