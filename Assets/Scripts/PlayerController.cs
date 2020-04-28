﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // common variables
    public float speed;
    private float _moveInput;
    private Rigidbody2D _rb;
    private bool _facingRight = true;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    
    // jump variables
    public float jumpForce;
    private int _extraJumps;
    public int extraJumpsValue;
    public bool isJumping;
    private float _jumpTimeCounter;
    public float JumpTime;


    // Start is called before the first frame update
    void Start()
    {
        _extraJumps = extraJumpsValue;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        _moveInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_moveInput * speed, _rb.velocity.y);

        if (_facingRight == false && _moveInput > 0)
        {
            Flip();
        } else if(_facingRight == true && _moveInput <0)
        {
            Flip();
        }
    }
    
    // For debug purposes
    private void OnGUI(){
        GUI.Label(new Rect(10, 10, Screen.width, Screen.height),"Velocity: " + _rb.velocity);
        GUI.Label(new Rect(10, 30, Screen.width, Screen.height),"Jumping: " + !isGrounded);
        GUI.Label(new Rect(10, 50, Screen.width, Screen.height),"Coordinates: " + _rb.position);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        var transform1 = transform;
        Vector3 scaler = transform1.localScale;
        scaler.x *= -1;
        transform1.localScale = scaler;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            _extraJumps = extraJumpsValue;
        }

        // TODO: remove this Input Input.GetKeyDown 
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && _extraJumps == 0)
        {
            isJumping = true;
            _jumpTimeCounter = JumpTime;
            _rb.velocity = Vector2.up * jumpForce;
        }

        // TODO: remove this Input Input.GetKeyDown
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (_jumpTimeCounter > 0)
            {
                _rb.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        // TODO: remove this Input Input.GetKeyDown
        if (Input.GetKeyUp(KeyCode.Space))
        {    
            isJumping = false;
        }


        // TODO: remove this Input Input.GetKeyDown
        if (Input.GetKeyDown(KeyCode.Space) && _extraJumps > 0)
        {
            isJumping = true;
            _jumpTimeCounter = JumpTime;
            _rb.velocity = Vector2.up * jumpForce / 3;
            _extraJumps--;
        }
    }
}
