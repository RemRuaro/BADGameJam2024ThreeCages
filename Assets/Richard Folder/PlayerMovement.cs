using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float SPD;

    public float Movespeed = 3.5f;
    public float Jumpforce = 7.0f;
    public float Fallmultiplier = 2.0f;
    private Rigidbody rb = null;
    private bool onGround = true;


    [SerializeField] GameObject gasDeath;
    [SerializeField] GameObject squishDeath;
    [SerializeField] GameObject goalPanel;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("gas"))
        {
            gasDeath.SetActive(true);
        }


        if (collision.gameObject.CompareTag("goal"))
        {
            Time.timeScale = 0;
            goalPanel.SetActive(true);
        }


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("squish"))
        {
            squishDeath.SetActive(true);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        { transform.Translate(Vector3.right * Time.deltaTime * SPD); }

        if (Input.GetKey(KeyCode.A))
        { transform.Translate(Vector3.left * Time.deltaTime * SPD); }

        this.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Movespeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) == true && onGround == true)
        {
            onGround = false;
            rb.AddForce(Vector3.up * Jumpforce, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Fallmultiplier * Time.deltaTime;
        }
    }

}
