using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;
    public static bool isInsideLadder = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isInsideLadder = true;
        }
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            print("Exit ladder");
            isInsideLadder = false;
        }
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
