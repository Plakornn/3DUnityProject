using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.AddScore(10); // เปลี่ยน Score เป็น 10 หรือค่าที่คุณต้องการ
            }
            Destroy(gameObject);
        }
    }
}
