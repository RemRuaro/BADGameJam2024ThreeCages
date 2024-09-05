using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is just for this scene for demo purposes. prefer to use the FPS camera of the actual scene.
 */
public class CameraLookAtEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    Transform enemy_pointer_transform;
    void Start()
    {
        enemy_pointer_transform = GameObject.FindGameObjectWithTag("TagEnemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(enemy_pointer_transform.position);
    }
}
