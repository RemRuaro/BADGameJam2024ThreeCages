using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePointerBase : MonoBehaviour
{
    Transform player_transform;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    [SerializeField] bool can_look_y_axis;
    void Start()
    {
        player_transform = GameObject.FindGameObjectWithTag("TagPlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (can_look_y_axis)
        {
            transform.LookAt(player_transform);
        }
        else
        {
            Vector3 new_target_position = player_transform.position;
            new_target_position.y = transform.position.y;

            transform.LookAt(new_target_position);
        }
    }
    

}
