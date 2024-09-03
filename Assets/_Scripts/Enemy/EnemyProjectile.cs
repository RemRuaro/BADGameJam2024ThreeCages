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
        if (collision.gameObject.tag == "Plaeyer") Destroy(this.gameObject);
        if (collision.gameObject.tag == "Ground") Destroy(this.gameObject);
    }
}
