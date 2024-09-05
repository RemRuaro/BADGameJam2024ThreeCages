using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyAngler : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player_transform;
    public float relative_angle;

    public int direction_index;

    /**
     * Usage instructions:
     * From editor, assign the sprite renderer of the child object that uses the `SpritePointerBase` script to sprite_face_sprite_renderer.
     * TODO: maybe we can programmatically assign this rather than via the editor?
     */
    public SpriteRenderer sprite_face_sprite_renderer;
    /**
     * Usage instructions:
     * From the editor, add in your sprites in clockwise sequence starting from front facing.
     * Add a duplicate entry for mirrored sprites (like left vs right -- meaning you upload the side sprite twice)
     */
    public Sprite[] sprites;
    /* TODO improvement if we have time. We can probably store the sprites in a 2D array
    one for sprite state (idle, attacking, etc.), and another for their directional variants */

    void Start()
    {
        player_transform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_position = new Vector3(player_transform.position.x, transform.position.y, player_transform.position.z);
        Vector3 target_direction = target_position - transform.position;
        relative_angle = Vector3.SignedAngle(target_direction, transform.forward, Vector3.up);
        direction_index = GetDirectionIndex(relative_angle);

        // if the player's relative angle is greater than 0, the sprite should be flipped, unless front and back sprites are used.
        bool should_flip_sprite = relative_angle < 0;
        // TODO: need a bugfix. for some reason the sprite is still being flipped despite the direction index being front or back...
        if ((direction_index != 0 || direction_index != 2) && should_flip_sprite)
        {
            Vector3 flipped = Vector3.one;
            flipped.x *= -1.0f;
            sprite_face_sprite_renderer.transform.localScale = flipped;
        }
        else
        {
            sprite_face_sprite_renderer.transform.localScale = Vector3.one;
        }

        sprite_face_sprite_renderer.sprite = sprites[direction_index];



    }
    
    /**
     * Currently built for 4 directions only
     */
    int GetDirectionIndex(float angle)
    {
        if (angle <= 45.0f && angle >= -45.0f) // front
        {
            return 0;
        }
        else if (angle >= 45.0f && angle <= 135.0f) // relative left
        {
            return 1;
        }
        else if ((angle >= 135.0f && angle <= 180.0f) || (angle <= -135.0f && angle >= -180.0f)) // back
        {
            return 2;
        }
        else // surely they're facing to the relative right :clueless:
        {
            return 3;
        }
    }

}
