using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float _moveInput;

    private Rigidbody2D _rb;

    private bool _facingRight = true;


    public bool isGrounded;

    public Transform groundCheck;
    
    public float checkRadius;

    public LayerMask whatIsGround;

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

        if (isGrounded == true)
        {
            _extraJumps = extraJumpsValue;
        }

        // single jump
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space) && _extraJumps == 0)
        {
            isJumping = true;
            _jumpTimeCounter = JumpTime;
            _rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (_jumpTimeCounter > 0)
            {
                _rb.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {    
            isJumping = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && _extraJumps >0)
        {
            isJumping = true;
            _jumpTimeCounter = JumpTime;
            _rb.velocity = Vector2.up * jumpForce / 3;
            _extraJumps--;
        }
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

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
