using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{

    [SerializeField] float moveSPD;
    [SerializeField] float swingSPD;
    [SerializeField] float strikeDepth;
    [SerializeField] float originalYPos;

    [SerializeField] bool trigger;
    [SerializeField] bool rise;


    void Start()
    {

        trigger = true;

    }



    void Update()
    {

        //transform.Translate(Vector3.forward * Time.deltaTime * moveSPD);


        if (this.gameObject.transform.position.y <= strikeDepth)
        {
            trigger = false;
            rise = true;
        }

        if (trigger)
        {
            transform.Translate(Vector3.down * Time.deltaTime * swingSPD);
        }

        if (rise)
        {
            transform.Translate(Vector3.up * Time.deltaTime * swingSPD);
        }



    }



}
