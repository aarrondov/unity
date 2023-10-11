using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedMove;
    public float jumpPower;
    public SpriteRenderer sprtRnd;
    public CinemachineVirtualCamera gobj;
    public float xOffset;
    public Animator animPlayer;
    public float climbingSpeed = 5f;
    public float horizontalMovementSpeed = 3f;
    
    private float horizontal;
    private bool isFacingRight = true;
    private bool isClimbing = false;
    // Start is called before the first frame update
    void Start()
    {
        // print("start");
        xOffset = gobj.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x;
        xOffset = 5f;
        // print(xOffset);
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        // print(CheckGround.isGrounded);
    }

    public void CheckMovement()
    {
        if (Math.Abs(horizontal) != 0f)
        {
            animPlayer.SetBool("isRunning",true);
        }
        else
        {
            animPlayer.SetBool("isRunning",false);
        }
        if (CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);
            animPlayer.SetBool("isGrounded",true);
        }
        else
        {
            animPlayer.SetBool("isGrounded",false);
        }

        if (horizontal > 0)
        {
            xOffset = 5f;
        }else if (horizontal < 0)
        {
            xOffset = -5f;
        }
        
        // print(xOffset);
        
        gobj.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x = xOffset;
        
        if (!isFacingRight && horizontal > 0f)
        {
            isFacingRight = true;
            sprtRnd.flipX = false;
        } 
        else if (isFacingRight && horizontal < 0f)
        {
            isFacingRight = false;
            sprtRnd.flipX = true;
        }

        if (CheckGround.isInsideLadder)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                print("r");
            }
        }
        else
        {
            isClimbing = false;
        }

        if (isClimbing)
        {
            print("Climbing");
            if (Input.GetKey(KeyCode.W))
            {
                // Mover al jugador hacia arriba en el eje Y
                rb.velocity = new Vector2(rb.velocity.x, climbingSpeed);
            }
            else
            {
                // Cuando dejes de presionar 'W', puedes mover al jugador hacia la derecha
                rb.velocity = new Vector2(rb.velocity.x, climbingSpeed);
            }
        }
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        //if (CheckGround.isGrounded)
        //{
            horizontal = context.ReadValue<Vector2>().x;
        //}
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);    
        }
    }

}
