using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void ToTitleScreen()
    { SceneManager.LoadScene(0); }


    public void ToLevel1()
    { SceneManager.LoadScene(1); }

    public void ToLevel2()
    { SceneManager.LoadScene(2); }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
