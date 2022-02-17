using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player velocity controll")]
    [SerializeField] private int xVelocity = 5;
    [SerializeField] private int yVelocity = 8;
    [Header("Player jump controll")]
    [SerializeField] private float timeToJump = 0.0f;
    [SerializeField] private float jumpDeltaTime = 1.5f;

    //
    private Rigidbody2D rigidBody;
    //========================================
    private void Start()
    {
        // 
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    //========================================
    private void Update()
    {
        updatePlayerPosition();
    }
    //=======================================


    private void updatePlayerPosition()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Jump");

        if (moveInput < 0)
        {
            rigidBody.velocity = new Vector2(-xVelocity, rigidBody.velocity.y);
        }
        else if (moveInput > 0)
        {
            rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
        }

        if (timeToJump > 0) timeToJump -= Time.deltaTime;
        if (jumpInput > 0 && timeToJump <= 0)
        {
            timeToJump = jumpDeltaTime;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
        }
    }
}
