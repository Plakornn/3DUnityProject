using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    public Text hpText;
    public PlayerController playerController;
  void Update()
    {
        hpText.text = "HP: " + GetCurrentHP().ToString();
    }

    int GetCurrentHP()
    {
        return playerController.currentHP;
        //int currentHP = 100; 
        //return currentHP;
    }
}
