using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControlsFirstPerson : MonoBehaviour
{
    [Header("Scriptable Object Reference")]
    [SerializeField] private DataPlayer _PlayerData;

    [Header("Player Movement System")]
    [SerializeField] private Transform _PlayerOrientation;
    Vector3 movementDirection;
    float inputHorizontal;
    float inputVertical;
    Rigidbody playerRb;

    [Header("Ground Checker")]
    public LayerMask _WhatIsGround;
    bool isGrounded;

    [Header("Shooting Controls")]
    [SerializeField] private Camera _PlayerCam;
    [SerializeField] private Transform _PlayerMuzzle;
    int projectilesFired;
    float counter;

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

        // Shooting controls
        if (counter < 1 / _PlayerData._PlayerRof)
        {
            counter += Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                projectilesFired = 0;
                FireProjectiles();
                counter = 0;
            }
        }
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

    private void FireProjectiles()
    {
        Ray ray = _PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint = ray.GetPoint(5.0f);
        if (Physics.Raycast(ray, out hit)) targetPoint = hit.point;

        float x = Random.Range(-_PlayerData._ProjectileSpread, _PlayerData._ProjectileSpread);
        float y = Random.Range(-_PlayerData._ProjectileSpread, _PlayerData._ProjectileSpread);
        float z = Random.Range(-_PlayerData._ProjectileSpread, _PlayerData._ProjectileSpread);

        Vector3 direction = targetPoint - _PlayerMuzzle.position;
        Vector3 directionWithSpread = direction + new Vector3(x, y, z);

        GameObject currentProjectile = Instantiate(_PlayerData._PlayerProjectile, _PlayerMuzzle.position, Quaternion.identity);
        currentProjectile.transform.forward = directionWithSpread.normalized;
        currentProjectile.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * _PlayerData._ProjectileForce, ForceMode.Impulse);

        projectilesFired++;

        if (projectilesFired < _PlayerData._ProjectileAmount)
        {
            Invoke(nameof(FireProjectiles), _PlayerData._TimeBetweenShots);
        }
    }
}
