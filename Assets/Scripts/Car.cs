using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public SteeringWheel wheel;
    public Pedal gasPedal;
    public Pedal brakePedal;

    public float movementSpeed;
    public float turningSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (transform.forward * (movementSpeed * gasPedal.GetNormalizedSpeed()) * Time.deltaTime);

        transform.position += transform.forward * ((movementSpeed * gasPedal.GetNormalizedDistance()) * Time.deltaTime);
        transform.Rotate((Vector3.up * wheel.GetNormalAngle() * turningSpeed) * Time.deltaTime);
    }
}
