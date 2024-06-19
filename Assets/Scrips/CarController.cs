using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider FLW;
    [SerializeField] WheelCollider FRW;
    [SerializeField] WheelCollider BLW;
    [SerializeField] WheelCollider BRW;

    [SerializeField] GameObject car;

    [SerializeField] private Type typeScript;

    public float acceleration = 500f;
    public float brakingForce = 300f;
    public float maxSteerAngle = 15f;
    public float downforce = 100f;

    public float constentTorque = 3000f;
    public bool isControlable = false;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentSteerAngle = 0f;

    public Rigidbody rb;
    private SFXManager sfxManager; // Reference to the SFXManager

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        // Find the Type script in the scene
        typeScript = FindObjectOfType<Type>();
        if (typeScript == null)
        {
            Debug.LogError("Type script not found!");
        }

        // Find the SFXManager GameObject
        GameObject sfxEngineObject = GameObject.Find("SFXEngine");

        if (sfxEngineObject != null)
        {
            sfxManager = sfxEngineObject.GetComponent<SFXManager>();
            if (sfxManager == null)
            {
                Debug.LogError("SFXManager component not found on the GameObject named 'SFXEngine'!");
            }
            else
            {
                sfxManager.PlayEngineSound(); // Start playing engine sound
            }
        }
        else
        {
            Debug.LogError("GameObject named 'SFXEngine' not found!");
        }
    }

    private void FixedUpdate()
    {
        if (typeScript == null || !typeScript.isTyping)
        {
            // Acceleration reverse/forward from vertical axis
            currentAcceleration = acceleration * Input.GetAxis("Vertical");

            // Steering from horizontal axis
            currentSteerAngle = maxSteerAngle * Input.GetAxis("Horizontal");
        }

        // Apply acceleration to front wheels Set value
        if (isControlable)
        {
            FLW.motorTorque = currentAcceleration;
            FRW.motorTorque = currentAcceleration;
            BLW.motorTorque = currentAcceleration;
            BRW.motorTorque = currentAcceleration;
        }
        else
        {
            FLW.motorTorque = constentTorque;
            FRW.motorTorque = constentTorque;
            BLW.motorTorque = constentTorque;
            BRW.motorTorque = constentTorque;
        }

        // Apply braking to all wheels
        FLW.brakeTorque = currentBrakeForce;
        FRW.brakeTorque = currentBrakeForce;
        BLW.brakeTorque = currentBrakeForce;
        BRW.brakeTorque = currentBrakeForce;

        // Apply steering to front wheels
        FLW.steerAngle = currentSteerAngle;
        FRW.steerAngle = currentSteerAngle;

        // Apply downforce
        rb.AddForce(-transform.up * downforce * rb.velocity.magnitude);

        // Set Z rotation back to 0
        float currentX = car.transform.eulerAngles.x;
        float currentY = car.transform.eulerAngles.y;
        car.transform.eulerAngles = new Vector3(currentX, currentY, 0);

        Debug.Log($"Motor Torque: {FLW.motorTorque}, Brake Torque: {FLW.brakeTorque}, Steer Angle: {FLW.steerAngle}");
    }
}
