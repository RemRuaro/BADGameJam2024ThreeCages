using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{

    [SerializeField] float moveSPD;
    [SerializeField] float swingSPD;
    [SerializeField] float liftSPD;

    [SerializeField] float max;
    [SerializeField] float min;

    bool move = true;

    void Start()
    {
        //StartCoroutine(Strike());
    }



    void Update()
    {

        transform.Translate(Vector3.right * Time.deltaTime * moveSPD);

        if (move)
        { transform.Translate(Vector3.up * Time.deltaTime * liftSPD); }
        if (!move)
        { transform.Translate(Vector3.down * Time.deltaTime * swingSPD); }

        if (transform.position.y >= max)
        { move = false; }
        if (transform.position.y <= min)
        { move = true; }
    }



    //IEnumerator Strike()
    //{
    //    while (true)
    //    {
    //        transform.Translate(Vector3.down * Time.deltaTime * swingSPD);
    //        yield return new WaitForSeconds(2);
    //        transform.Translate(Vector3.up * Time.deltaTime * liftSPD);
    //        yield return new WaitForSeconds(2);
    //    }

    //}



}
