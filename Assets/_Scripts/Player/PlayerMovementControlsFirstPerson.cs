using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControlsFirstPerson : MonoBehaviour
{
    [Header("Scriptable Object Reference")]
    [SerializeField] DataPlayer _PlayerData;

    [Header("Player Movement System")]
    [SerializeField] Transform _PlayerOrientation;
    Vector3 movementDirection;
    float inputHorizontal;
    float inputVertical;
    Rigidbody playerRb;

    [Header("Ground Checker")]
    public LayerMask _WhatIsGround;
    bool isGrounded;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
    }

    void Update()
    {
        // Ground checker
        isGrounded = Physics.Raycast(transform.position, Vector3.down, _PlayerData._PlayerHeight * 0.5f + 0.2f, _WhatIsGround);
        
        PlayerInput();

        // Drag handler
        if (isGrounded) playerRb.drag = _PlayerData._PlayerGroundDrag;
        else playerRb.drag = 0;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerInput()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMovement()
    {
        // Calculate movement direction
        // Player object will move to any direction where the player points the camera to
        movementDirection = _PlayerOrientation.forward * inputVertical + _PlayerOrientation.right * inputHorizontal;

        // Add force
        playerRb.AddForce(movementDirection.normalized * _PlayerData._PlayerSpeed * 10.0f, ForceMode.Force);
    }
}
