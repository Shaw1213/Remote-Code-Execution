using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Transform ReStartPoint;
    private CarController carController;
    private SFXManager sfxManager; // Reference to the SFXManager

    void Start()
    {
        carController = GameObject.Find("Car").GetComponent<CarController>();
        GameObject sfxEngineObject = GameObject.Find("SFXEngine"); // Find the SFXEngine GameObject by name

        if (sfxEngineObject != null)
        {
            sfxManager = sfxEngineObject.GetComponent<SFXManager>(); // Get the SFXManager component from the found GameObject
        }
        else
        {
            Debug.LogError("SFXEngine GameObject not found!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
            Debug.Log("Trap");
            carController.transform.position = ReStartPoint.position;
            carController.transform.eulerAngles = new Vector3(0, 180, 0);
            carController.rb.velocity = Vector3.zero;

            // Play the crash sound
            if (sfxManager != null)
            {
                sfxManager.PlayCrashSound();
            }
        
    }
}
