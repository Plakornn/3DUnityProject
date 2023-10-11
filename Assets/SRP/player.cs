using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;
    public float jumpForce = 10.0f; // ปรับค่า jumpForce ให้มากขึ้นเพื่อกระโดดเร็วขึ้น
    public float gravity = 9.81f; // เพิ่มฟิลด์สำหรับค่าแรงโน้มถ่วง

    private bool isGrounded = false; // เพิ่มตัวแปรสำหรับตรวจสอบการแตะพื้น

    void Start()
    {
        Physics.gravity = new Vector3(0, -500f, 0);
    }

    void FixedUpdate()
    {
        // ตรวจสอบการกดปุ่มควบคุมเคลื่อนที่
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
            // หยุดเคลื่อนที่เมื่อไม่กดปุ่มควบคุม
            playerRigid.velocity = Vector3.zero;
        }
    }

    void Update()
    {

        // ตรวจสอบการกดปุ่มควบคุมการเดิน
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                float jumpSpeed = Mathf.Sqrt(2 * jumpForce * Mathf.Abs(Physics.gravity.y));
                playerRigid.velocity = new Vector3(playerRigid.velocity.x, jumpSpeed, playerRigid.velocity.z);
                playerAnim.SetTrigger("jump");
            }
        }
		
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float rayDistance = 0.1f;
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(rayOrigin, Vector3.down, out hit))
        {
            isGrounded = true;
            return true;
        }

        isGrounded = false;
        return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}