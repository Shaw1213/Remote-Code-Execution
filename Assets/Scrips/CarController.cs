using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider FLW;
    [SerializeField] WheelCollider FRW;
    [SerializeField] WheelCollider BLW;
    [SerializeField] WheelCollider BRW;

    public float acceleration = 500f;
    public float brakingForce = 300f;
    public float maxSteerAngle = 15f;
    public float downforce = 100f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentSteerAngle = 0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        // Acceleration reverse/forward from vertical axis
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // Steering from horizontal axis
        currentSteerAngle = maxSteerAngle * Input.GetAxis("Horizontal");

        // Braking with Key Space
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakeForce = brakingForce;
        }
        else
        {
            currentBrakeForce = 0f;
        }

        // Apply acceleration to front wheels
        FLW.motorTorque = 3000;
        FRW.motorTorque = 3000;

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

        // Debug logging
        Debug.Log($"Motor Torque: {FLW.motorTorque}, Brake Torque: {FLW.brakeTorque}, Steer Angle: {FLW.steerAngle}");
    }
}
