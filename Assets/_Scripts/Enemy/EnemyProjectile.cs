using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TagPlayer") Destroy(this.gameObject);
        if (collision.gameObject.tag == "TagGround") Destroy(this.gameObject);
    }
}
