using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBox : MonoBehaviour
{

    void Start()
    {
        
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win");
        SceneManager.LoadScene(1);
    }
}
