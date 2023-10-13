using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;
    public float jumpForce = 2000.0f;
    public Text scoreText;
    private int score = 0;
    private bool isGrounded = false;
    public int maxHP = 100; // HP สูงสุด
    public int currentHP; // HP ปัจจุบัน
    public Text hpText;
    public int enemyDamage = 10; // ความเสียหายจากศัตรู


    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0); 
        scoreText.text = "Score: " + score;
        Physics.gravity = new Vector3(0, -500f, 0);
        currentHP = maxHP;
        UpdateHPText();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
        else
        {
            playerRigid.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed = w_speed + rn_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                w_speed = olw_speed;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
        if (SceneManager.GetActiveScene().name == "lose&Score")
        {
            EndGame();
        }
        if (SceneManager.GetActiveScene().name == "Winner&Score")
        {
            EndGame();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            score += 10;
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            scoreText.text = "Score: " + score;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            TakeDamage(enemyDamage);
        }
    }

    public void AddScore(int value)
    {
        score += value; 
        scoreText.text = "Score: " + score; 
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        scoreText.text = "Score: " + score;
    }
    void UpdateHPText()
    {
        hpText.text = "HP: " + currentHP.ToString();
        if (currentHP <= 0)
        {
            currentHP = 0;
            EndGame();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateHPText();
        if (currentHP <= 0)
        {
            currentHP = 0; 
            // ดำเนินการเมื่อ HP น้อยกว่าหรือเท่ากับ 0 (Game Over, แสดง Game Over Screen, ฯลฯ)
        }
        UpdateHPText();
    }

    
    void EndGame()
    {
        PlayerPrefs.SetInt("Score", score); 
        PlayerPrefs.Save();
   
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        } 
        SceneManager.LoadScene(3);
    }

}
