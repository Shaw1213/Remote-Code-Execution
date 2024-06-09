using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Transform ReStartPoint;

    private CarController carController;

    void Start()
    {
        carController = GameObject.Find("Car").GetComponent<CarController>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trap");
        carController.transform.position = ReStartPoint.position;
        
    }
}
