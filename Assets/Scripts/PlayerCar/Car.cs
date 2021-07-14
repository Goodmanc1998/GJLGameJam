using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public SteeringWheel steeringWheel;
    public Pedal gasPedal;
    public Pedal brakePedal;

    public float acceleration, steering, brake;

    float accNorm, steeringNorm, brakeNorm;

    public WheelCollider fl, rl, fr, rr;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        accNorm = gasPedal.GetNormalizedDistance();
        steeringNorm = steeringWheel.GetNormalAngle();
        brakeNorm = brakePedal.GetNormalizedDistance();

    }

    private void FixedUpdate()
    {

        Steer();

        rl.motorTorque = accNorm * acceleration;
        rr.motorTorque = accNorm * acceleration;

        fl.brakeTorque = brakeNorm * brake;
        fr.brakeTorque = brakeNorm * brake;
        rl.brakeTorque = brakeNorm * brake;
        rr.brakeTorque = brakeNorm * brake;

    }

    void Steer()
    {
        float nSteering = steeringNorm * steering;

        fr.steerAngle = nSteering;
        fl.steerAngle = nSteering;
    }
}
