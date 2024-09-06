using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] bool X;
    [SerializeField] bool Z;
    [SerializeField] float speed;
    [SerializeField] float max;
    [SerializeField] float min;

    bool move = true;
    [SerializeField] bool go = true;

    void Update()
    {
        if (go)
        {
            if (Z)
            {
                if (move)
                { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
                if (!move)
                { transform.Translate(Vector3.back * Time.deltaTime * speed); }

                if (transform.position.z >= max)
                { move = false; }
                if (transform.position.z <= min)
                { move = true; }
            }

            if (X)
            {
                if (move)
                { transform.Translate(Vector3.right * Time.deltaTime * speed); }
                if (!move)
                { transform.Translate(Vector3.left * Time.deltaTime * speed); }

                if (transform.position.x >= max)
                { move = false; }
                if (transform.position.x <= min)
                { move = true; }
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        { collision.transform.SetParent(transform); }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        { collision.transform.SetParent(null); }
    }

}
