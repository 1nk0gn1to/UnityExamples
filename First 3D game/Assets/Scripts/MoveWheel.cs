using UnityEngine;

public class MoveWheel : MonoBehaviour
{
    public WheelCollider wheelColliderFL;
    public WheelCollider wheelColliderFR;
    public WheelCollider wheelColliderRL;
    public WheelCollider wheelColliderRR;

    public Transform transformFL;
    public Transform transformFR;
    public Transform transformRL;
    public Transform transformRR;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float turnAngle = 45f;

    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
        }
        else
        {
            currentBreakingForce = 0f;
        }

        wheelColliderFL.motorTorque = currentAcceleration;
        wheelColliderFR.motorTorque = currentAcceleration;

        wheelColliderFL.brakeTorque = currentBreakingForce;
        wheelColliderFR.brakeTorque = currentBreakingForce;
        wheelColliderRL.brakeTorque = currentBreakingForce;
        wheelColliderRR.brakeTorque = currentBreakingForce;

        currentTurnAngle = turnAngle * Input.GetAxis("Horizontal");
        wheelColliderFL.steerAngle = currentTurnAngle;
        wheelColliderFR.steerAngle = currentTurnAngle;

        UpdateWheel(wheelColliderFL, transformFL);
        UpdateWheel(wheelColliderFR, transformFR);
        UpdateWheel(wheelColliderRL, transformRL);
        UpdateWheel(wheelColliderRR, transformRR);
    }
    
    void UpdateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;
        collider.GetWorldPose(out pos, out quat);
        quat = quat * Quaternion.Euler(new Vector3(0, 90, 0));
        transform.position = pos;
        transform.rotation = quat;
    }
}