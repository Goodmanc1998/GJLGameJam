using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public SteeringWheel steeringWheel;
    public Pedal gasPedal;
    public Pedal brakePedal;
    public DirectionalButton direction;

    public float acceleration, steering, brake;

    //EDIT Ben -- Added a velocity variable for the engine pitch and a ref to rb to get velocity
    float accNorm, steeringNorm, brakeNorm, dir;

    public float velocity;
    Rigidbody theCar;

    public WheelCollider fl, rl, fr, rr;

    // Start is called before the first frame update
    void Start()
    {
        theCar = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        accNorm = gasPedal.GetNormalizedDistance();
        steeringNorm = steeringWheel.GetNormalAngle();
        brakeNorm = brakePedal.GetNormalizedDistance();

        dir = direction.GetDirection();

        

    }

    private void FixedUpdate()
    {

        Steer();

        rl.motorTorque = (accNorm * acceleration) * dir;
        rr.motorTorque = (accNorm * acceleration) * dir;

        fl.brakeTorque = brakeNorm * brake;
        fr.brakeTorque = brakeNorm * brake;
        rl.brakeTorque = brakeNorm * brake;
        rr.brakeTorque = brakeNorm * brake;

        velocity = theCar.velocity.magnitude;

    }

    void Steer()
    {
        float nSteering = steeringNorm * steering;

        fr.steerAngle = nSteering;
        fl.steerAngle = nSteering;
    }

}
