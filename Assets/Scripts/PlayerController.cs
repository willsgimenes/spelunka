using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;


    public bool isGrounded;

    public Transform groundCheck;
    
    public float checkRadius;

    public LayerMask whatIsGround;

    private int extraJumps;

    public int extraJumpsValue;

    public bool isJumping;

    private float JumpTimeCounter;

    public float JumpTime;



    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // void Update()
    // {

    //     if (isGrounded == true)
    //     {
    //         extraJumps = extraJumpsValue;
    //     }z

    //     if (Input.GetKeyDown(KeyCode.Space) && extraJumps >0)
    //     {
    //         rb.velocity = Vector2.up * jumpForce;
    //         extraJumps--;
    //     } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps ==0 && isGrounded == true)
    //     {
    //         rb.velocity = Vector2.up * jumpForce;
    //     }
    // }

    void Update()
    {

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        // single jump
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space) && extraJumps == 0)
        {
            isJumping = true;
            JumpTimeCounter = JumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                JumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps >0)
        {
            isJumping = true;
            JumpTimeCounter = JumpTime;
            rb.velocity = Vector2.up * jumpForce / 3;
            extraJumps--;
        }
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput <0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
