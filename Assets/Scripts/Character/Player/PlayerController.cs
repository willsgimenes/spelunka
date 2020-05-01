using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // common variables
    public float speed;
    private float _moveInput;
    private float _horizontalMove;
    public CharacterController2D controller;


    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * 400f;

        controller.Jump();

    }

    private void FixedUpdate()
    {
        controller.Move(_horizontalMove * Time.fixedDeltaTime);
    }
}
