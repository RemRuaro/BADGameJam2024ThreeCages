using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovementFirstPerson : MonoBehaviour
{
    [SerializeField] Transform _PositionCamera;

    void Update()
    {
        transform.position = _PositionCamera.position;
    }
}
