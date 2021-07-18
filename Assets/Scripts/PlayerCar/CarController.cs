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

    bool active = false;

    //EDIT Ben -- Added a velocity variable for the engine pitch and a ref to rb to get velocity
    float accNorm, steeringNorm, brakeNorm, dir;

    public float velocity;
    Rigidbody theCar;

    public WheelCollider fl, rl, fr, rr;

    private void OnEnable()
    {
        GameManager.onGameEvent += Event;
    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= Event;
    }

    // Start is called before the first frame update
    void Start()
    {
        theCar = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            if (theCar.velocity.magnitude < 15)
            {
                accNorm = gasPedal.GetNormalizedDistance();
            }
            else
                accNorm = 0;

            steeringNorm = steeringWheel.GetNormalAngle();
            brakeNorm = brakePedal.GetNormalizedDistance();

            dir = direction.GetDirection();
        }
        else
        {
            accNorm = 0;
            steeringNorm = 0;
            brakeNorm = 1;

            dir = 0;
        }

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

    void Event(GameEvents currEvent)
    {
        if (currEvent == GameEvents.PLAYER_ACTIVE)
        {
            active = true;
            steeringWheel.active = true;
        }
            

        if (currEvent == GameEvents.GAME_OVER)
        {
            active = false;
            steeringWheel.active = false;
        }
            
    }

}
