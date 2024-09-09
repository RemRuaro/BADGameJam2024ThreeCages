using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCameraSetupFirstPerson : MonoBehaviour
{
    [SerializeField] private DataPlayer _PlayerData;
    [SerializeField] Transform _PlayerOrientation;
    float rotationX;
    float rotationY;

    void Start()
    {
        //Locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Gets mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _PlayerData._MouseSensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _PlayerData._MouseSensitivityY;
        
        // Adds x input to y rotation
        rotationY += mouseX;
        
        // Subtracts y input to x rotation
        rotationX -= mouseY;

        // Limits vertical mouse look up to b degrees above or below the x axis
        rotationX = Mathf.Clamp(rotationX, -45f, 45f);

        // Camera rotations
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        _PlayerOrientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
