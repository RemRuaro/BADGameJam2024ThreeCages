using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaygonHand : MonoBehaviour
{
    [SerializeField] GameObject gasCloud;
    [SerializeField] float gasDuration;


    void Start()
    {
        StartCoroutine(GasSpawn());
    }



    void Update()
    {


    }


    IEnumerator GasSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(gasDuration);
            gasCloud.SetActive(true);
            yield return new WaitForSeconds(gasDuration);
            gasCloud.SetActive(false);
        }

    }


}
